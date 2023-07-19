using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

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

    [Test, Category("WebApi - Routing - Health")]
    [Description("Verifica endpoint de health")]
    public async Task HealthEndpoint_ShouldReturnOk()
    {
        var endpoint = "/health";

        var response = await _client.GetAsync(endpoint);

        var content = await response.Content.ReadAsStringAsync();
        Assert.That(content, Is.EqualTo("OK"));
    }

    [Test, Category("WebApi - Routing - Validate")]
    [Description("Verifica endpoint de validação")]
    public async Task ValidateEndpoint_WithValidIdAndText_ShouldReturnOk()
    {
        var textExample = "Example Text";
        var endpoint = "/api/v1/validate?id=" + Guid.NewGuid() + "&text=" + textExample;

        var response = await _client.GetAsync(endpoint);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotImplemented));
    }

    [Test, Category("WebApi - Routing - Validate")]
    [TestCase("")]
    [TestCase("texto teste")]
    [Description("Verifica endpoint de validação caso falte algum parametro")]
    public async Task ValidateEndpoint_WithMissingText_ShouldReturnBadRequest(string text)
    {
        var endpoint = $"/api/v1/validate?";

        if (string.IsNullOrEmpty(text))
            endpoint += "id=" + Guid.NewGuid();
        else
            endpoint += "text=" + text;

        var response = await _client.GetAsync(endpoint);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [Test, Category("WebApi - Routing - Rank")]
    [Description("Verifica endpoint de rank sem guid")]
    public async Task RankEndpoint_ShouldReturnOk()
    {
        var endpoint = "/api/v1/rank";

        var response = await _client.GetAsync(endpoint);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotImplemented));
    }

    [Test, Category("WebApi - Routing - Rank")]
    [Description("Verifica endpoint de rank com guid")]
    public async Task RankByIdEndpoint_WithValidId_ShouldReturnOk()
    {
        var id = Guid.NewGuid();
        var endpoint = $"/api/v1/rank/{id}";

        var response = await _client.GetAsync(endpoint);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotImplemented));
    }
}
