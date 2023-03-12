using API.Configurations;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Adding configurations from JSON files
builder.Host.AddConfigurations();

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseInfrastructure(builder.Configuration);
app.MapEndpoints();
app.Run();
