using Core.BocaSuja.Domain.Entities;

namespace Tests.UnitTests.Core.BocaSuja.Domain.Entities;

[TestFixture]
public class IncidenciaTest
{
    [Test, Category("Core - Domain - Entidade - Incidencia")]
    [TestCase("Comentário em video", "Sexual", 0)]
    [TestCase("Título do vídeo", "Ódio", 1)]
    [TestCase("Descrição do video", "Violência", 3)]
    [Description("Verifica se a entidade Incidência é instanciada corretamente.")]
    public void InstantiateIncidencia_ShouldInstantiate(
        string validRecurso,
        string validTipo,
        int validGravidade
    )
    {
        var dateTimeBefore = DateTimeOffset.Now.AddSeconds(-1);
        var validEntitadeOfensora = Guid.NewGuid();

        var validIncidencia = new Incidencia(
            validEntitadeOfensora,
            validRecurso,
            validTipo,
            validGravidade
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
            Assert.That(validIncidencia.DataHoraCriacao, Is.GreaterThan(dateTimeBefore));
            Assert.That(validIncidencia.DataHoraCriacao, Is.LessThan(dateTimeAfter));
        });
    }
}
