using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Models;

namespace Core.BocaSuja.LLMContext;

public class AzureContentSafetyContext : IGenericLlmContext
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
