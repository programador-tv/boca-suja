using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Infrastructure.Context.DbMapping;
using Microsoft.EntityFrameworkCore;

namespace Core.BocaSuja.Infrastructure.Context;

public class BocaSujaDbContext : DbContext
{
    public BocaSujaDbContext(DbContextOptions<BocaSujaDbContext> options)
        : base(options) { }

    public DbSet<Incidencia> Incidencias { get; set; }

    private readonly IncidenciaDbMapping IncidenciaMapping = new();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        IncidenciaMapping.Build(modelBuilder);
    }
}
