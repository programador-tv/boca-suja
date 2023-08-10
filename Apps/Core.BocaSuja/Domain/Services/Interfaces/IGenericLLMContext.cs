namespace Core.BocaSuja.Domain.Interfaces;

public interface IGenericLlmContext
{
    public bool Validate(Guid Id, string Text);
}
