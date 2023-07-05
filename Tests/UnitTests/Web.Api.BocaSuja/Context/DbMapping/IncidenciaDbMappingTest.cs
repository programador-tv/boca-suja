using Core.BocaSuja.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Web.Api.BocaSuja.Context.DbMapping;

namespace Tests.UnitTests.Web.Api.BocaSuja.Context.DbMapping;

[TestFixture]
public class IncidenciaDbMappingTest
{
    private ModelBuilder _modelBuilder;
    private IncidenciaDbMapping _incidenciaDbMapping;

    [SetUp]
    public void Setup()
    {
        _modelBuilder = new ModelBuilder();
        _incidenciaDbMapping = new IncidenciaDbMapping();
    }

    [Test, Category("WebApi - Context - DbMappings - IncidenciaDbMapping")]
    [Description("Verifica o método Build.")]
    public void BuildTest()
    {
        _incidenciaDbMapping.Build(_modelBuilder);

        var incidencia = _modelBuilder.Model.FindEntityType(typeof(Incidencia));

        Assert.Multiple(() =>
        {
            Assert.That(actual: incidencia, Is.Not.Null);
            Assert.That(actual: incidencia?.GetTableName(), Is.EqualTo("Incidencias"));
            Assert.That(actual: incidencia?.GetDeclaredIndexes().Count(), Is.EqualTo(1));
        });

        Assert.Pass();
    }
}
