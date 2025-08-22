using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Ofernandoavila.Academy.API.Configurations.Swagger;
using Ofernandoavila.Academy.Business.Interfaces.Settings;
using Ofernandoavila.Academy.Business.Models.Settings;
using Ofernandoavila.Academy.Data.Context;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<AppDbContext>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddScoped<INotificator, Notificator>();

            return services;
        }
    }
}
