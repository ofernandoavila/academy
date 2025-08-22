using Asp.Versioning.ApiExplorer;
using k8s.Models;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ofernandoavila.Academy.API.Configurations.Swagger
{
    public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            foreach(var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            }
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Ofernandoavila | Academy API",
                Version = "1.0.0",
                Description = "This is the Academy API by Fernando Ávila.",
                Contact = new OpenApiContact() { Name = "Fernando Ávila", Email = "fernandoavilajunior@gmail.com" }
            };

            if (description.IsDeprecated)
                info.Description += " This version is deprecated!";

            return info;
        }
    }
}
