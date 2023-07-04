using Core.BocaSuja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Configuration.Context.DbMapping;

namespace Web.Api.BocaSuja.Configuration.Context;

public class BocaSujaDbContext : DbContext
{
  public BocaSujaDbContext(DbContextOptions<BocaSujaDbContext> options) : base(options)
  {

  }

  public DbSet<Incidencia> Incidencias { get; set; }

  private readonly IncidenciaDbMapping IncidenciaMapping = new();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    IncidenciaMapping.Build(modelBuilder);
  }
}
