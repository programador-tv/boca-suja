using Core.BocaSuja;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test]
    public void HealthAppShouldReturnOk()
    {
        var response = Health.Check();
    }
}
