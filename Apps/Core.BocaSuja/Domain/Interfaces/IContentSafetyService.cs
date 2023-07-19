using Core.BocaSuja.Domain.Entities;

namespace Core.BocaSuja.Domain.Interfaces;

public interface IContentSafetyService
{
    public Task<bool> Validate(Guid id, string text);
    public Task<List<Incidencia>> Rank();
    public Task<List<Incidencia>> Rank(Guid id);
}
