using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Models;

namespace Core.BocaSuja.Factories;

public static class LLMContextFactory
{
    public static IGenericLLMContext UseAzureContentSafety(
        AzureContentSafetyCredentials credentials
    )
    {
        return new AzureContentSafetyContext(credentials);
    }
}
