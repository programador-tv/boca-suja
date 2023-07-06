using Core.BocaSuja;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Context;
using Web.Api.BocaSuja.HealthCheck;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BocaSujaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"))
);

var app = builder.Build();

DbHealthCheck.Check(app.Services);

app.MapGet("/health", () => "OK");
app.MapGet("/app/health", () => Health.Check());

app.Run();
