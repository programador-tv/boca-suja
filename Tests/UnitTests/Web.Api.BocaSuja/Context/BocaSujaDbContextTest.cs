using Core.BocaSuja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Context;

namespace Tests.UnitTests.Web.Api.BocaSuja.Context;

[TestFixture]
public class BocaSujaDbContextTest
{
    private DbContextOptions<BocaSujaDbContext> _options;

    [SetUp]
    public void Setup()
    {
        _options = new DbContextOptionsBuilder<BocaSujaDbContext>()
            .UseInMemoryDatabase(databaseName: "TesteDb")
            .Options;
    }

    [Test, Category("WebApi - Context - BocaSujaDbContext")]
    [TestCase("Comentário em video", "Sexual", 0)]
    [TestCase("Título do vídeo", "Ódio", 1)]
    [TestCase("Descrição do video", "Violência", 3)]
    [Description("Verifica a instancia do banco em memória e a persistencia de alguns dados.")]
    public void InstantiateDbContext(string validRecurso, string validTipo, int validGravidade)
    {
        using var dbContext = new BocaSujaDbContext(_options);
        var entidadeOfensoraGuid = Guid.NewGuid();

        var incidencia = new Incidencia(
            entidadeOfensoraGuid,
            validRecurso,
            validTipo,
            validGravidade
        );

        dbContext.Incidencias.Add(incidencia);
        dbContext.SaveChanges();

        var incidenciaPersistida = dbContext.Incidencias.Find(incidencia.Id);

        Assert.Multiple(() =>
        {
            Assert.That(actual: dbContext.Incidencias.Count(), Is.AtLeast(1));
            Assert.That(actual: incidenciaPersistida, Is.InstanceOf(typeof(Incidencia)));
            Assert.That(actual: incidenciaPersistida, Is.Not.Null);
            Assert.That(actual: incidenciaPersistida?.Id, Is.InstanceOf(typeof(Guid)));
            Assert.That(
                actual: incidenciaPersistida?.EntidadeOfensora,
                Is.EqualTo(incidencia.EntidadeOfensora)
            );
            Assert.That(actual: incidenciaPersistida?.Recurso, Is.EqualTo(incidencia.Recurso));
            Assert.That(actual: incidenciaPersistida?.Tipo, Is.EqualTo(incidencia.Tipo));
            Assert.That(actual: incidenciaPersistida?.Gravidade, Is.EqualTo(incidencia.Gravidade));
            Assert.That(
                actual: incidenciaPersistida?.DataHoraCriacao,
                Is.EqualTo(incidencia.DataHoraCriacao)
            );
        });
    }
}
