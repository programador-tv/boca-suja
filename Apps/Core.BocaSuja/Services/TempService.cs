using Core.BocaSuja.Domain.Interfaces;

public class TempService
{
    private IGenericLLMContext _context;

    public TempService(IGenericLLMContext context)
    {
        _context = context;
    }

    public bool Check(Guid id, string text)
    {
        return _context.Validate(Id: id, Text: text);
    }
}
