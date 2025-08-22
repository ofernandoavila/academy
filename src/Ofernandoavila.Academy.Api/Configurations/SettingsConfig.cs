using Ofernandoavila.Academy.Business.Models.Settings;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class SettingsConfig
    {
        public static WebApplicationBuilder AddAppSettingsConfiguration(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.Configure<AppSettings>(configuration.GetSection(AppSettings.AppConfig));
            builder.Services.Configure<AppCredentials>(configuration.GetSection("AppCredentials"));

            return builder;
        }
    }
}
