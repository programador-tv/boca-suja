using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Enums;

namespace Tests.UnitTests.Core.BocaSuja.Domain.Entities;

[TestFixture]
public class IncidenciaTest
{
    [Test, Category("Core - Domain - Entidade - Incidencia")]
    [TestCase("Comentário em video", TipoDeIncidenciaEnum.SEXUAL, 0)]
    [TestCase("Título do vídeo", TipoDeIncidenciaEnum.SELFHARM, 1)]
    [TestCase("Descrição do video", TipoDeIncidenciaEnum.HATE, 2)]
    [TestCase("Descrição do video", TipoDeIncidenciaEnum.VIOLENCE, 3)]
    [Description("Verifica se a entidade Incidência é instanciada corretamente.")]
    public void InstantiateIncidencia_ShouldInstantiate(
        string validRecurso,
        TipoDeIncidenciaEnum validTipo,
        int validGravidade
    )
    {
        var dateTimeBefore = DateTimeOffset.Now.AddSeconds(-1);
        var textoExemplo = "Texto exemplo de uma incidência";
        var validEntitadeOfensora = Guid.NewGuid();

        var validIncidencia = new Incidencia(
            validEntitadeOfensora,
            validRecurso,
            validTipo,
            validGravidade,
            textoExemplo
        );

        var dateTimeAfter = DateTimeOffset.Now.AddSeconds(1);

        Assert.Multiple(() =>
        {
            Assert.That(validIncidencia, Is.InstanceOf(typeof(Incidencia)));
            Assert.That(validIncidencia, Is.Not.Null);
            Assert.That(validIncidencia.Id, Is.InstanceOf(typeof(Guid)));
            Assert.That(validEntitadeOfensora, Is.EqualTo(validIncidencia.EntidadeOfensora));
            Assert.That(validRecurso, Is.EqualTo(validIncidencia.Recurso));
            Assert.That(validTipo, Is.EqualTo(validIncidencia.Tipo));
            Assert.That(validGravidade, Is.EqualTo(validIncidencia.Gravidade));
            Assert.That(textoExemplo, Is.EqualTo(validIncidencia.Texto));
            Assert.That(validIncidencia.DataHoraCriacao, Is.GreaterThan(dateTimeBefore));
            Assert.That(validIncidencia.DataHoraCriacao, Is.LessThan(dateTimeAfter));
        });
    }
}
