using Core.BocaSuja.Domain.Entities;

namespace Core.BocaSuja.Domain.Services.Interfaces;

public interface IContentSafetyService
{
    public Task<bool> Validate(Guid id, string text);
}
