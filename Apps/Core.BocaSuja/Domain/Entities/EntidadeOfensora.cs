using Core.BocaSuja.Domain.Entities.Base;

namespace Core.BocaSuja.Domain.Entities;

public class EntidadeOfensora : EntidadeBase
{
    public string ApelidoEntidade { get; private set; }

    public EntidadeOfensora(string apelidoEntidade) : base()
    {
        ApelidoEntidade = apelidoEntidade;
    }
}