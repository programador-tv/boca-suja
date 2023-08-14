using Core.BocaSuja.Infrastructure.Repositories.Interfaces;

namespace Core.BocaSuja.Domain.Interfaces;

public interface IGenericLlmContext
{
    public Task<bool> Validate(string Id, string Text);
}
