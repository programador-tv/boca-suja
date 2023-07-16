using Core.BocaSuja.Domain.Entities;

namespace Core.BocaSuja.Domain.Interfaces;
public interface IContentSafetyService
{
    public bool Validate(Guid id, string text);
    public List<Incidencia> Rank();
    public List<Incidencia> Rank(Guid id);
}
