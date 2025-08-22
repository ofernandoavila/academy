using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ofernandoavila.Academy.Business.Models.Settings;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class JWTConfig
    {
        public static WebApplicationBuilder AddJWTConfiguration(this WebApplicationBuilder builder)
        {
            var appSettings = builder.Configuration.GetSection(AppSettings.AppConfig).Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            builder.Services.AddAuthentication(t =>
            {
                t.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                t.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(t =>
              {
                  t.RequireHttpsMetadata = true;
                  t.SaveToken = true;
                  t.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudiences = appSettings.ValidIn,
                      ValidIssuer = appSettings.Emitter,
                      ClockSkew = TimeSpan.Zero
                  };
              });

            return builder;
        }
    }
}
