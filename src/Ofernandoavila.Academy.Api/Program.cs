using Ofernandoavila.Academy.API.Configurations;
using Ofernandoavila.Academy.API.Configurations.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAppCredentialsSettingsConfiguration(builder.Configuration);
builder.Services.AddAppSettingsConfiguration(builder.Configuration);
builder.Services.AddJWTConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(typeof(AutomapperConfig));
builder.Services.AddLoggerConfig(builder.Configuration);
builder.Services.ApiBehaviorConfig();
builder.Services.ApiVersioningConfig(); 
builder.Services.ApiCorsConfig();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.ResolveDependencies();

var app = builder.Build();

app.MigrateDatabase();
app.UseApiConfiguration(builder.Environment);
app.UseSwaggerConfig();
app.UseLoggerConfiguration();
app.UseEndPointsConfiguration();

app.Run();
