using Core.BocaSuja;
using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Factories;
using Core.BocaSuja.Models;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Context;
using Web.Api.BocaSuja.HealthCheck;

var builder = WebApplication.CreateBuilder(args);
var dbHealth = new DbHealthCheck();

var connectionString =
    Environment.GetEnvironmentVariable("DbContext")
    ?? builder.Configuration.GetConnectionString("DbContext")
    ?? string.Empty;

builder.Services.AddDbContext<BocaSujaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSingleton(
    LLMContextFactory.UseAzureContentSafety(
        credentials: new AzureContentSafetyCredentials(builder.Configuration)
    )
);
builder.Services.AddSingleton<TempService>();

var app = builder.Build();

dbHealth.Check(app.Services);

app.MapGet("/health", () => "OK");
app.MapGet("/app/health", () => Health.Check());
app.MapGet(
    "/app/temp",
    () =>
    {
        var tempService = app.Services.GetService(typeof(TempService)) as TempService;
        return tempService?.Check(Guid.NewGuid(), "Test");
    }
);

app.Run();
