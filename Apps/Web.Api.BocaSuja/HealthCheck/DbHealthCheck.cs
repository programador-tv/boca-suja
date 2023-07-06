using Core.BocaSuja;
using Web.Api.BocaSuja.Context;

namespace Web.Api.BocaSuja.HealthCheck;

public class DbHealthCheck
{
    public static bool Check(IServiceProvider appService)
    {
        try
        {
            using var scope = appService.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<BocaSujaDbContext>();
            return context.Database.EnsureCreated();
        }
        catch (Exception)
        {
            throw new Exception("Falha de conexão com o banco de dados");
        }
    }
}
