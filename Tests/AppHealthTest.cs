using Core.BocaSuja;

namespace Tests;

public class Tests
{
    [SetUp]
    public void Setup() { }

    [Test, Category("HealthCheck")]
    [Description("Teste do HealthCheck")]
    public void HealthAppShouldReturnOk()
    {
        var response = Health.Check();
        var ok = "OK";

        Assert.Multiple(() =>
        {
            Assert.That(response, Is.Not.Null);
            Assert.That(actual: response, Is.EqualTo(ok));
        });
    }
}
