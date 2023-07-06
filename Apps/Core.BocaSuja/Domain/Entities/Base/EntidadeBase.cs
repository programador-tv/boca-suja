namespace Core.BocaSuja.Domain.Entities.Base;

public abstract class EntidadeBase
{
    public Guid Id { get; private set; }
    public DateTimeOffset DataHoraCriacao { get; private set; }
    public DateTimeOffset DataHoraAtualizacao { get; private set; }
    public bool Inativo { get; private set; }

    protected EntidadeBase()
    {
        Id = Guid.NewGuid();
        DataHoraCriacao = DateTimeOffset.Now;
        DataHoraAtualizacao = DateTimeOffset.Now;
        Inativo = false;
    }
}
