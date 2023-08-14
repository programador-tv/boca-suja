using Core.BocaSuja.Domain.Interfaces;
using Core.BocaSuja.Infrastructure.Repositories.Interfaces;
using Core.BocaSuja.LLMContext;
using Core.BocaSuja.Models;

namespace Core.BocaSuja.Factories;

public static class LLMContextFactory
{
    public static IGenericLlmContext UseAzureContentSafety(
        AzureContentSafetyCredentials credentials,
        IEntidadeOfensoraRepository entidadeOfensoraRepository,
        IIncidenciaRepository incidenciaRepository
        )
    {
        return new AzureContentSafetyContext(
            credentials, 
            entidadeOfensoraRepository, 
            incidenciaRepository);
    }
}
