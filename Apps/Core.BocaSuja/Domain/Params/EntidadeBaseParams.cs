namespace Core.BocaSuja.Domain.Params;

public abstract class EntidadeBaseParams : IParams
{
    public Guid? Id { get; set; }
    public bool? Inativo { get; set; }
}
