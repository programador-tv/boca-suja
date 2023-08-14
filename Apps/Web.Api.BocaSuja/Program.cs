using Core.BocaSuja;
using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Factories;
using Core.BocaSuja.Models;
using Core.BocaSuja.Infrastructure.Context;
using Core.BocaSuja.Infrastructure.Repositories;
using Core.BocaSuja.Infrastructure.Repositories.Interfaces;
using Core.BocaSuja.LLMContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.HealthCheck;

var builder = WebApplication.CreateBuilder(args);
var dbHealth = new DbHealthCheck();

var connectionString =
    Environment.GetEnvironmentVariable("DbContext")
    ?? builder.Configuration.GetConnectionString("DbContext")
    ?? string.Empty;

builder.Services.AddDbContext<BocaSujaDbContext>(options => 
    options.UseSqlServer(connectionString, 
        b => b.MigrationsAssembly("Web.Api.BocaSuja")));

builder.Services.AddScoped<IEntidadeOfensoraRepository, EntidadeOfensoraRepository>();
builder.Services.AddScoped<IIncidenciaRepository, IncidenciaRepository>();

builder.Services.AddScoped<IGenericLlmContext, AzureContentSafetyContext>(serviceProvider =>
{
    var entidadeOfensoraRepo = serviceProvider.GetRequiredService<IEntidadeOfensoraRepository>();
    var incidenciaRepo = serviceProvider.GetRequiredService<IIncidenciaRepository>();
    
    return (LLMContextFactory.UseAzureContentSafety(
        credentials: new AzureContentSafetyCredentials(builder.Configuration),
        entidadeOfensoraRepository: entidadeOfensoraRepo!,
        incidenciaRepository: incidenciaRepo!
    ) as AzureContentSafetyContext)!;
});

// builder.Services.AddScoped<IContentSafetyService, AzureContentSafetyService>();

var app = builder.Build();

dbHealth.Check(app.Services);

app.MapGet("/app/health", () => Health.Check());

app.MapGet(
    "/api/v1/validate",
    async (string id, string? text, IGenericLlmContext safetyService) =>
    {
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(text))
        {
            return Results.BadRequest(new BadHttpRequestException("'id' or 'text' parameter"));
        }
        try
        {
            return Results.Ok(await safetyService.Validate(id, text));
        }
        catch (Exception ex)
        {
            return Results.Problem(detail: ex.Message, statusCode: 501);
        }
    }
);

app.MapGet(
    "/api/v1/rank",
    async ([FromServices] BocaSujaDbContext _context) => {
        // try
        // {
        //     return Results.Ok(await safetyService.Rank());
        // }
        // catch (Exception ex)
        // {
        //     return Results.Problem(detail: ex.Message, statusCode: 501);
        // }
    }
);

app.MapGet(
    "/api/v1/rank/{id}",
    async (Guid id, [FromServices] BocaSujaDbContext _context) => {
        // try
        // {
        //     return Results.Ok(await safetyService.Rank(id));
        // }
        // catch (Exception ex)
        // {
        //     return Results.Problem(detail: ex.Message, statusCode: 501);
        // }
    }
);

app.Run();

public partial class Program { }
