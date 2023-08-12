using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Enums;
using Core.BocaSuja.Domain.Params;
using Core.BocaSuja.Infrastructure.Context;
using Core.BocaSuja.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Tests.UnitTests.Core.BocaSuja.Infrastructure.Repositories;

[TestFixture]
public class IncidenciaRepositoryTests
{
    private BocaSujaDbContext _dbContext;
    private IncidenciaRepository _incidenciaRepository;

    [SetUp]
    public void Setup()
    {
        var options = new DbContextOptionsBuilder<BocaSujaDbContext>()
            .UseInMemoryDatabase(databaseName: "test_db")
            .Options;

        _dbContext = new BocaSujaDbContext(options);
        _incidenciaRepository = new IncidenciaRepository(_dbContext);
    }

    [TearDown]
    public void TearDown()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Dispose();
    }

    [Test, Category("Core - Infrastructure - Repository - IncidenciaRepository")]
    [Description("Verifica se retorna todas as incidencias listadas.")]
    public async Task Select_ReturnsAllIncidencias()
    {
        // Arrange
        var incidencia1 = new Incidencia(
            Guid.NewGuid(),
            "Título",
            TipoDeIncidencia.HATE,
            2,
            "Texto teste"
        );
        var incidencia2 = new Incidencia(
            Guid.NewGuid(),
            "Comentário",
            TipoDeIncidencia.SELFHARM,
            5,
            "Texto teste 2"
        );

        _dbContext.Incidencias.AddRange(incidencia1, incidencia2);
        await _dbContext.SaveChangesAsync();

        // Act
        var result = await _incidenciaRepository.Select().ToListAsync();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result.Any(i => i.Id == incidencia1.Id), Is.True);
            Assert.That(result.Any(i => i.Id == incidencia2.Id), Is.True);
            Assert.That(result.Any(i => i.Gravidade == incidencia1.Gravidade), Is.True);
            Assert.That(result.Any(i => i.Gravidade == incidencia2.Gravidade), Is.True);
        });
    }

    [Test, Category("Core - Infrastructure - Repository - IncidenciaRepository")]
    [Description("Verifica a seleção por Id.")]
    public async Task SelectById_ShouldReturnOneOrNull()
    {
        // Arrange
        var incidencia1 = new Incidencia(
            Guid.NewGuid(),
            "Título",
            TipoDeIncidencia.HATE,
            2,
            "Texto teste"
        );
        var incidencia2 = new Incidencia(
            Guid.NewGuid(),
            "Comentário",
            TipoDeIncidencia.SELFHARM,
            5,
            "Texto teste 2"
        );

        _dbContext.Incidencias.AddRange(incidencia1, incidencia2);
        await _dbContext.SaveChangesAsync();

        // Act
        var validResult = await _incidenciaRepository.Select(incidencia2.Id);
        var noResult = await _incidenciaRepository.Select(Guid.NewGuid());

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(validResult, Is.Not.Null);
            Assert.That(noResult, Is.Null);
            Assert.That(validResult!.Gravidade, Is.EqualTo(incidencia2.Gravidade));
            Assert.That(validResult!.EntidadeOfensora, Is.EqualTo(incidencia2.EntidadeOfensora));
            Assert.That(validResult!.Texto, Is.EqualTo(incidencia2.Texto));
        });
    }

    [Test, Category("Core - Infrastructure - Repository - IncidenciaRepository")]
    [TestCase("398A1F57-9B4D-45F6-85E1-8502BB6C349B", null, null, null, null)]
    [TestCase(null, "Comentário em video", TipoDeIncidencia.SEXUAL, null, null)]
    [TestCase("398A1F57-9B4D-45F6-85E1-8502BB6C349B", null, null, 5, null)]
    [TestCase(null, null, null, 5, null)]
    [TestCase(null, null, null, null, "teXto ExEMpLO")]
    [TestCase(null, "ComEntÁrIo eM ViDeo", null, null, null)]
    [Description("Verifica filtrar as incidencias por parâmetros")]
    public async Task SelectByParams_ShouldReturnByParams(
        string? entidadeOfensoraString,
        string? recurso,
        TipoDeIncidencia? tipo,
        int? gravidade,
        string? texto
    )
    {
        // Arrange
        var incidencia1 = new Incidencia(
            Guid.NewGuid(),
            "Título",
            TipoDeIncidencia.HATE,
            2,
            "Texto teste"
        );

        var incidencia2 = new Incidencia(
            Guid.NewGuid(),
            "Comentário",
            TipoDeIncidencia.SELFHARM,
            3,
            "Texto teste 2"
        );

        var incidencia3 = new Incidencia(
            new Guid("398A1F57-9B4D-45F6-85E1-8502BB6C349B"),
            "Comentário em video",
            TipoDeIncidencia.SEXUAL,
            5,
            "texto exemplo"
        );

        var incidencia4 = new Incidencia(
            new Guid("398A1F57-9B4D-45F6-85E1-8502BB6C349B"),
            "Comentário em video",
            TipoDeIncidencia.SEXUAL,
            5,
            "texto exemplo"
        );

        var incidenciaParams = new IncidenciaParams
        {
            EntidadeOfensora = entidadeOfensoraString.IsNullOrEmpty()
                ? null
                : new Guid(entidadeOfensoraString!),
            Gravidade = gravidade ?? null,
            Texto = texto ?? null,
            Tipo = tipo ?? null,
            Recurso = recurso ?? null
        };

        _dbContext.Incidencias.AddRange(incidencia1, incidencia2, incidencia3, incidencia4);
        await _dbContext.SaveChangesAsync();

        //Act
        var result = await _incidenciaRepository.Select(incidenciaParams).ToListAsync();

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.TrueForAll(x => x.Texto == incidencia3.Texto), Is.True);
        });
    }

    [Test, Category("Core - Infrastructure - Repository - IncidenciaRepository")]
    [TestCase("Comentário em video", TipoDeIncidencia.SEXUAL, 0, "texto teste1")]
    [TestCase("Título do vídeo", TipoDeIncidencia.SELFHARM, 1, "texto teste2")]
    [TestCase("Descrição do video", TipoDeIncidencia.HATE, 2, "texto teste3")]
    [TestCase("Descrição do video", TipoDeIncidencia.VIOLENCE, 3, "texto teste4")]
    [Description("Verifica se as incidencia são registradas no banco.")]
    public async Task Insert_AddsIncidenciaToDatabase(
        string recurso,
        TipoDeIncidencia tipo,
        int gravidade,
        string texto
    )
    {
        // Arrange
        var newIncidencia = new Incidencia(Guid.NewGuid(), recurso, tipo, gravidade, texto);

        // Act
        await _incidenciaRepository.Insert(newIncidencia);

        // Assert
        var result = await _dbContext.Incidencias.FirstOrDefaultAsync(
            i => i.Id == newIncidencia.Id
        );

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Id, Is.EqualTo(newIncidencia.Id));
            Assert.That(result!.EntidadeOfensora, Is.EqualTo(newIncidencia.EntidadeOfensora));
            Assert.That(result!.Gravidade, Is.EqualTo(newIncidencia.Gravidade));
            Assert.That(result!.Recurso, Is.EqualTo(newIncidencia.Recurso));
            Assert.That(result!.Texto, Is.EqualTo(newIncidencia.Texto));
            Assert.That(result!.DataHoraAtualizacao, Is.EqualTo(newIncidencia.DataHoraAtualizacao));
            Assert.That(result!.DataHoraCriacao, Is.EqualTo(newIncidencia.DataHoraCriacao));
        });
    }
}
