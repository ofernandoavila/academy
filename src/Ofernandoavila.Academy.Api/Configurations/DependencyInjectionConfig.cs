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
        public static WebApplicationBuilder ResolveDependencies(this WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            builder.Services.AddScoped<INotificator, Notificator>();

            return builder;
        }
    }
}
