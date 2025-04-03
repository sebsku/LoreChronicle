using DotNetEnv;
using Events.Api.Endpoints;
using Events.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

Env.Load();

builder.Services.AddApplication();
builder.Services.AddDatabase(Environment.GetEnvironmentVariable("TimescaleDb_ConnectionString")
                             ?? builder.Configuration.GetConnectionString("TimescaleDb")!);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapApiEndpoints();

app.Run();


