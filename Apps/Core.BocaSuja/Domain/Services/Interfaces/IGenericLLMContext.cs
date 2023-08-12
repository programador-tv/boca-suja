namespace Core.BocaSuja.Domain.Interfaces;

public interface IGenericLlmContext
{
    public Task<bool> Validate(string Id, string Text);
}
