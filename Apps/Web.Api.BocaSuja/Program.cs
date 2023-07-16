using Core.BocaSuja;
using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Context;
using Web.Api.BocaSuja.HealthCheck;

var builder = WebApplication.CreateBuilder(args);
var dbHealth = new DbHealthCheck();

builder.Services.AddDbContext<BocaSujaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"))
);

builder.Services.AddScoped<IContentSafetyService, AzureContentSafetyService>();

var app = builder.Build();

dbHealth.Check(app.Services);

app.MapGet("/health", () => "OK");
app.MapGet("/app/health", () => Health.Check());

app.MapGet(
    "/api/v1/validate",
    async (Guid? id, string? text, [FromServices] AzureContentSafetyService safetyService) =>
    {
        if (id.HasValue && !string.IsNullOrEmpty(text))
        {
            return Results.Ok(await safetyService.Validate(id.Value, text));
        }
        else
        {
            return Results.BadRequest("Missing 'id' or 'text' parameter.");
        }
    }
);

app.MapGet(
    "/api/v1/rank",
    async (AzureContentSafetyService safetyService) => Results.Ok(await safetyService.Rank())
);

app.MapGet(
    "/api/v1/rank/{id}",
    async (Guid id, AzureContentSafetyService safetyService) =>
        Results.Ok(await safetyService.Rank(id))
);

app.Run();
