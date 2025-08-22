using Microsoft.EntityFrameworkCore;
using Ofernandoavila.Academy.Data.Context;

namespace Ofernandoavila.Academy.API.Configurations
{
    public static class DatabaseConfig
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.CommandTimeout(30);
                        npgsqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(5), null);
                    }
                );
            });

            return services;
        }

        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using var context = GetDbContextService(app);
            context.Database.SetCommandTimeout(TimeSpan.FromMinutes(5));
            context.Database.Migrate();

            return app;
        }

        private static AppDbContext GetDbContextService(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            return scope.ServiceProvider.GetService<AppDbContext>();
        }
    }
}
