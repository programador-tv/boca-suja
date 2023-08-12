using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.LLMContext;
using Core.BocaSuja.Models;

namespace Core.BocaSuja.Factories;

public static class LLMContextFactory
{
    public static IGenericLlmContext UseAzureContentSafety(
        AzureContentSafetyCredentials credentials
    )
    {
        return new AzureContentSafetyContext(credentials);
    }
}
