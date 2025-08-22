using AutoMapper;

namespace Ofernandoavila.Academy.API.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {

        }
    }

    public static class AutomapperConfiguration
    {
        public static WebApplicationBuilder AddAutomapperConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(AutomapperConfig));

            return builder;
        }
    }
}
