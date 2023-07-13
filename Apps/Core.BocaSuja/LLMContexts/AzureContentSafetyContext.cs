using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Models;

public class AzureContentSafetyContext : IGenericLLMContext
{
    private AzureContentSafetyCredentials _credentials;

    public AzureContentSafetyContext(AzureContentSafetyCredentials credentials)
    {
        _credentials = credentials;
    }

    public bool Validate(Guid Id, string Text)
    {
        return true;
    }
}
