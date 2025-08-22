using Microsoft.AspNetCore.HttpLogging;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class LoggerConfig
    {
        public static WebApplicationBuilder AddLoggerConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpLogging(logging =>
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

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddHealthChecks();

            builder.Services.AddHealthChecksUI()
                    .AddInMemoryStorage();

            return builder;
        }

        public static IApplicationBuilder UseLoggerConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpLogging();

            return app;
        }
    }
}
