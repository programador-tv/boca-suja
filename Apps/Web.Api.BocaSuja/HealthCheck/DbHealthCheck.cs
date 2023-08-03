using Core.BocaSuja.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.BocaSuja.HealthCheck;

public class DbHealthCheck
{
    public bool Check(IServiceProvider appService)
    {
        using var scope = appService.CreateScope();
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<BocaSujaDbContext>();
        return context.Database.EnsureCreated();
    }
}