using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Entities.Base;
using Core.BocaSuja.Infrastructure.Context.DbMapping;
using Microsoft.EntityFrameworkCore;

namespace Core.BocaSuja.Infrastructure.Context;

public class BocaSujaDbContext : DbContext
{
    public BocaSujaDbContext(DbContextOptions<BocaSujaDbContext> options)
        : base(options) { }

    public DbSet<Incidencia> Incidencias { get; set; }
    public DbSet<EntidadeOfensora> EntidadeOfensoras { get; set; }

    private readonly IncidenciaDbMapping IncidenciaMapping = new();
    private readonly EntidadeOfensoraDbMapping EntidadeOfensoraMapping = new();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        IncidenciaMapping.Build(modelBuilder);
        EntidadeOfensoraMapping.Build(modelBuilder);
    }
}
