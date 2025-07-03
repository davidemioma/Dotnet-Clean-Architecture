// Use "dotnet new webapi -n folderName" to create a new .NET webapi project.
// Use "dotnet watch run" to run project.

using Application.DependencyInjection;
using Infastructure.DependencyInjection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplicationServices();

builder.Services.AddInfastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(); // https://localhost:<port>/scalar/v1 to run.
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
