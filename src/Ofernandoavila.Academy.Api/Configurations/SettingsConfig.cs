using Ofernandoavila.Academy.Business.Models.Settings;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class SettingsConfig
    {
        public static IServiceCollection AddAppSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(section);

            return services;
        }

        public static IServiceCollection AddAppCredentialsSettingsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("AppCredentials");
            services.Configure<AppCredentials>(section);

            return services;
        }
    }
}
