using Asp.Versioning;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Ofernandoavila.Academy.API.Extensions;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder ApiBehaviorConfig(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            builder.Services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    });

            return builder;
        }

        public static WebApplicationBuilder ApiVersioningConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                    new HeaderApiVersionReader("x-api-version"),
                                                                    new MediaTypeApiVersionReader("x-api-version"));
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return builder;
        }

        public static WebApplicationBuilder ApiCorsConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Default", buider => buider.AllowAnyOrigin()
                                                             .AllowAnyMethod()
                                                             .AllowAnyHeader());

                options.AddPolicy("Production", builder => builder.AllowAnyOrigin()
                                                                  .AllowAnyHeader()
                                                                  .AllowAnyMethod());
            });

            return builder;
        }
        public static WebApplicationBuilder AddApiExplorer(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();

            return builder;
        }

        public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) => {
                context.Request.EnableBuffering();
                await next();
            });

            if (env.IsProduction())
            {
                app.UseCors("Production");
                app.UseHsts();
            }
            else
            {
                app.UseCors("Default");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMiddleware<SecurityMiddleware>(env);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }

        public static IApplicationBuilder UseEndPointsConfiguration(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

                endpoints.MapHealthChecksUI(options =>
                {
                    options.UIPath = "/monitor";
                    options.ApiPath = "/health-ui-api";
                    options.WebhookPath = "/da-webhooks";
                    options.ResourcesPath = "/my-resources";
                    options.UseRelativeApiPath = true;
                    options.UseRelativeResourcesPath = true;
                    options.UseRelativeWebhookPath = true;
                });
            });

            return app;
        }
    }
}
