using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Domain.Services;

namespace Tests.UnitTests.Core.BocaSuja.Domain.Services;

[TestFixture]
public class AzureContentSafetyServiceTest
{
    private AzureContentSafetyService _contentSafetyService;

    [SetUp]
    public void SetUp()
    {
        _contentSafetyService = new AzureContentSafetyService();
    }

    [Test, Category("Core - Domain - Services - AzureContentSafetyService")]
    [Description("Não implementado")]
    public void Rank_ThrowsNotImplementedException()
    {
        async Task action() => await _contentSafetyService.Rank();

        Assert.ThrowsAsync<NotImplementedException>(action);
    }

    [Test, Category("Core - Domain - Services - AzureContentSafetyService")]
    [Description("Não implementado")]
    public void Rank_WithId_ThrowsNotImplementedException()
    {
        var id = Guid.NewGuid();

        async Task action() => await _contentSafetyService.Rank(id);

        Assert.ThrowsAsync<NotImplementedException>(action);
    }

    [Test, Category("Core - Domain - Services - AzureContentSafetyService")]
    [Description("Não implementado")]
    public void Validate_ThrowsNotImplementedException()
    {
        var id = Guid.NewGuid();
        var text = "Test text";

        async Task action() => await _contentSafetyService.Validate(id, text);

        Assert.ThrowsAsync<NotImplementedException>(action);
    }
}
