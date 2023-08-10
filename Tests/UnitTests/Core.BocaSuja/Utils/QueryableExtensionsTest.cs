using Core.BocaSuja.Utils;

namespace Tests.UnitTests.Core.BocaSuja.Utils;

[TestFixture]
public class QueryableExtensionsTest
{
    private struct ObjetoTeste
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Active { get; set; }
    }

    [Test, Category("Core - Utils - QueryableExtensions")]
    [Description("Verifica se o método de WhereIf funciona corretamente")]
    public void WhereIf_ShouldReturnQueryable()
    {
        // Arrange
        var query = new List<ObjetoTeste>
        {
            new ObjetoTeste
            {
                Id = 1,
                Nome = "Objeto 1",
                Active = true
            },
            new ObjetoTeste
            {
                Id = 2,
                Nome = "Objeto 2",
                Active = false
            },
            new ObjetoTeste
            {
                Id = 3,
                Nome = "Objeto 3",
                Active = true
            },
            new ObjetoTeste
            {
                Id = 4,
                Nome = "Objeto 4",
                Active = true
            },
            new ObjetoTeste
            {
                Id = 5,
                Nome = "Objeto 5",
                Active = true
            }
        }.AsQueryable();

        // Act
        var shouldResultAllActive = query
            .WhereIf(query.Count() > 1, x => x.Active == true)
            .WhereIf(query.Count() > 10, x => x.Id < 3)
            .ToList();

        var shouldResultJustActiveWithIdThreeOrLess = query
            .WhereIf(query.Count() < 10, x => x.Active == true)
            .WhereIf(query.Count() < 10, x => x.Id <= 3)
            .ToList();

        var shouldResultAll = query
            .WhereIf(query.Count() > 50, x => x.Active == true)
            .WhereIf(query.Count() > 10, x => x.Id < 3)
            .ToList();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(shouldResultAllActive, Has.Count.EqualTo(4));
            Assert.That(shouldResultJustActiveWithIdThreeOrLess, Has.Count.EqualTo(2));
            Assert.That(shouldResultAll, Has.Count.EqualTo(query.ToList().Count));
        });
    }
}
