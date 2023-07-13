namespace Core.BocaSuja.Domain.Interfaces;

public interface IGenericLLMContext
{
    public bool Validate(Guid Id, string Text);
}
