using Core.BocaSuja.Domain.Entities.Base;
using Core.BocaSuja.Domain.Enums;

namespace Core.BocaSuja.Domain.Entities;

public class Incidencia : EntidadeBase
{
    public Guid EntidadeOfensora { get; private set; }
    public string Recurso { get; private set; }
    public TipoDeIncidencia Tipo { get; private set; }
    public int Gravidade { get; private set; }
    public string Texto { get; private set; }

    public Incidencia(
        Guid entidadeOfensora,
        string recurso,
        TipoDeIncidencia tipo,
        int gravidade,
        string texto
    )
        : base()
    {
        EntidadeOfensora = entidadeOfensora;
        Recurso = recurso;
        Tipo = tipo;
        Gravidade = gravidade;
        Texto = texto;
    }
}
