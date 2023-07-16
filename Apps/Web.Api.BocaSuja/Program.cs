using Core.BocaSuja;
using Core.BocaSuja.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Context;
using Web.Api.BocaSuja.HealthCheck;

var builder = WebApplication.CreateBuilder(args);
var dbHealth = new DbHealthCheck();

builder.Services.AddDbContext<BocaSujaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"))
);

var app = builder.Build();

dbHealth.Check(app.Services);

app.MapGet("/health", () => "OK");
app.MapGet("/app/health", () => Health.Check());

app.MapGet(
    "/api/v1/validate?id={id}&text={text}",
    async (Guid id, String text, AzureContentSafetyService safetyService) =>
        Results.Ok(await safetyService.Validate(id, text))
);

app.MapGet(
    "/api/v1/rank",
    async (AzureContentSafetyService safetyService) => Results.Ok(await safetyService.Rank())
);

app.MapGet(
    "/api/v1/rank?id={id}",
    async (Guid id, AzureContentSafetyService safetyService) =>
        Results.Ok(await safetyService.Rank(id))
);

app.Run();
