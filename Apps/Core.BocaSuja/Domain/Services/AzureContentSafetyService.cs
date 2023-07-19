using Core.BocaSuja.Domain.Entities;
using Core.BocaSuja.Domain.Interfaces;

namespace Core.BocaSuja.Domain.Services;

public class AzureContentSafetyService : IContentSafetyService
{
    public Task<List<Incidencia>> Rank()
    {
        throw new NotImplementedException();
    }

    public Task<List<Incidencia>> Rank(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Validate(Guid id, string text)
    {
        throw new NotImplementedException();
    }
}
