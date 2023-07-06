using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Enums;

namespace Tests.UnitTests.Core.BocaSuja.Domain.Entities;

[TestFixture]
public class IncidenciaTest
{
    [Test, Category("Core - Domain - Entidade - Incidencia")]
    [TestCase("Comentário em video", TipoDeIncidencia.SEXUAL, 0)]
    [TestCase("Título do vídeo", TipoDeIncidencia.SELFHARM, 1)]
    [TestCase("Descrição do video", TipoDeIncidencia.HATE, 2)]
    [TestCase("Descrição do video", TipoDeIncidencia.VIOLENCE, 3)]
    [Description("Verifica se a entidade Incidência é instanciada corretamente.")]
    public void InstantiateIncidencia_ShouldInstantiate(
        string validRecurso,
        TipoDeIncidencia validTipo,
        int validGravidade
    )
    {
        var dateTimeBefore = DateTimeOffset.Now.AddSeconds(-1);
        var textoExemplo = "Texto exemplo de uma incidência";
        var validEntidadeOfensora = Guid.NewGuid();

        var validIncidencia = new Incidencia(
            validEntidadeOfensora,
            validRecurso,
            validTipo,
            validGravidade,
            textoExemplo
        );

        var dateTimeAfter = DateTimeOffset.Now.AddSeconds(1);

        Assert.Multiple(() =>
        {
            Assert.That(actual: validIncidencia, Is.InstanceOf(typeof(Incidencia)));
            Assert.That(actual: validIncidencia, Is.Not.Null);
            Assert.That(actual: validIncidencia.Id, Is.InstanceOf(typeof(Guid)));
            Assert.That(
                actual: validIncidencia.EntidadeOfensora,
                Is.EqualTo(validEntidadeOfensora)
            );
            Assert.That(actual: validIncidencia.Recurso, Is.EqualTo(validRecurso));
            Assert.That(actual: validIncidencia.Tipo, Is.EqualTo(validTipo));
            Assert.That(actual: validIncidencia.Gravidade, Is.EqualTo(validGravidade));
            Assert.That(actual: validIncidencia.Texto, Is.EqualTo(textoExemplo));
            Assert.That(actual: validIncidencia.DataHoraCriacao, Is.GreaterThan(dateTimeBefore));
            Assert.That(actual: validIncidencia.DataHoraCriacao, Is.LessThan(dateTimeAfter));
            Assert.That(
                actual: validIncidencia.DataHoraAtualizacao,
                Is.GreaterThan(dateTimeBefore)
            );
            Assert.That(actual: validIncidencia.DataHoraAtualizacao, Is.LessThan(dateTimeAfter));
            Assert.That(actual: validIncidencia.Inativo, Is.False);
        });
    }
}
