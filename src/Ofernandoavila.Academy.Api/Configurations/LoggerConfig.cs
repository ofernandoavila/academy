using Microsoft.AspNetCore.HttpLogging;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.RequestBody |
                                        HttpLoggingFields.RequestQuery |
                                        HttpLoggingFields.RequestProperties;
                logging.RequestHeaders.Add("sec-ch-ua");
                logging.ResponseHeaders.Add("ResponseHeader");
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });

            services.AddHttpContextAccessor();

            services.AddHealthChecks();

            services.AddHealthChecksUI()
                    .AddInMemoryStorage();

            return services;
        }

        public static IApplicationBuilder UseLoggerConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpLogging();

            return app;
        }
    }
}
