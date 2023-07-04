using Core.BocaSuja;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Configuration.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BocaSujaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"))
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BocaSujaDbContext>();
    context.Database.EnsureCreated();
}

app.MapGet("/health", () => "OK");
app.MapGet("/app/health", () => Health.Check());

app.Run();
