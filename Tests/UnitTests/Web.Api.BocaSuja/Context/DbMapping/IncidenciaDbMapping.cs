using Microsoft.EntityFrameworkCore;

namespace Tests.UnitTests.Web.Api.BocaSuja.Context.DbMapping;

[TestFixture]
public class IncidenciaDbMapping
{

    private ModelBuilder _modelBuilder;
    private IncidenciaDbMapping _incidenciaDbMapping;

    [SetUp]
    public void Setup()
    {
        _modelBuilder = new ModelBuilder();
        _incidenciaDbMapping = new IncidenciaDbMapping();
    }

}
