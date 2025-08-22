using Microsoft.EntityFrameworkCore;
using Ofernandoavila.Academy.Data.Context;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class DatabaseConfig
    {
        public static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.CommandTimeout(30);
                        npgsqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
                    }
                );
            });

            return builder;
        }

        public static async Task<IApplicationBuilder> MigrateDatabase(this IApplicationBuilder app)
        {
            using var context = GetDbContextService(app);
            context.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));
            await context.Database.MigrateAsync();

            return app;
        }

        private static AppDbContext GetDbContextService(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            return scope.ServiceProvider.GetService<AppDbContext>();
        }
    }
}
