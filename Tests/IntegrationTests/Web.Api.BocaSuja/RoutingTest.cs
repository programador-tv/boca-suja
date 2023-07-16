using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Tests.IntegrationTests.Web.Api.BocaSuja;
[TestFixture]
public class IntegrationTests
{
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

    [OneTimeSetUp]
    public void Setup()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _client.Dispose();
        _factory.Dispose();
    }

    [Test]
    public async Task HealthEndpoint_ShouldReturnOk()
    {
        var endpoint = "/health";

        var response = await _client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content, Is.EqualTo("OK"));
    }

    [Test]
    public async Task ValidateEndpoint_WithValidIdAndText_ShouldReturnOk()
    {
        var textExample = "Example Text";
        var endpoint = "/api/v1/validate?id=" + Guid.NewGuid() + "&text=" + textExample;

        var response = await _client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task RankEndpoint_ShouldReturnOk()
    {
        var endpoint = "/api/v1/rank";

        var response = await _client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();
    }

    [Test]
    public async Task RankByIdEndpoint_WithValidId_ShouldReturnOk()
    {
        var id = Guid.NewGuid();
        var endpoint = $"/api/v1/rank/{id}";

        var response = await _client.GetAsync(endpoint);

        response.EnsureSuccessStatusCode();
    }
}
