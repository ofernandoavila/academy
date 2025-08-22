using Ofernandoavila.Academy.API.Configurations;
using Ofernandoavila.Academy.API.Configurations.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabase()
       .AddAppSettingsConfiguration()
       .AddJWTConfiguration()
       .AddAutomapperConfig()
       .AddLoggerConfig()
       .ApiBehaviorConfig()
       .ApiVersioningConfig()
       .ApiCorsConfig()
       .AddSwaggerConfig()
       .ResolveDependencies()
       .AddApiExplorer();

var app = builder.Build();

app.UseApiConfiguration(builder.Environment)
   .UseSwaggerConfig()
   .UseLoggerConfiguration()
   .UseEndPointsConfiguration()
   .MigrateDatabase().Wait();

app.Run();
