using Api.Configurations;
using Application.Configurations;
using Persistence.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .ConfigureApi()
    .ConfigureApplication()
    .ConfigurePersistence(builder.Configuration);

var app = builder.Build();

app.UseApi()
    .Run();