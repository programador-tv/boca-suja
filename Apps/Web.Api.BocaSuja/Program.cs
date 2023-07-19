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
    async (Guid? id, string? text, [FromServices] IContentSafetyService safetyService) =>
    {
        if (id.HasValue && !string.IsNullOrEmpty(text))
        {
            try
            {
                return Results.Ok(await safetyService.Validate(id.Value, text));
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 501);
            }
        }
        else
        {
            return Results.BadRequest(new BadHttpRequestException("'id' or 'text' parameter"));
        }
    }
);

app.MapGet(
    "/api/v1/rank",
    async ([FromServices] IContentSafetyService safetyService) =>
    {
        try
        {
            return Results.Ok(await safetyService.Rank());
        }
        catch (Exception ex)
        {
            return Results.Problem(detail: ex.Message, statusCode: 501);
        }
    }
);

app.MapGet(
    "/api/v1/rank/{id}",
    async (Guid id, [FromServices] IContentSafetyService safetyService) =>
    {
        try
        {
            return Results.Ok(await safetyService.Rank(id));
        }
        catch (Exception ex)
        {
            return Results.Problem(detail: ex.Message, statusCode: 501);
        }
    }
);

app.Run();

public partial class Program { }
