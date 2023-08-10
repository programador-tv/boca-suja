using Core.BocaSuja.Domain.Interfaces;

namespace Core.BocaSuja.Services;

public class TempService
{
    private IGenericLlmContext _context;

    public TempService(IGenericLlmContext context)
    {
        _context = context;
    }

    public bool Check(Guid id, string text)
    {
        return _context.Validate(Id: id, Text: text);
    }
}
