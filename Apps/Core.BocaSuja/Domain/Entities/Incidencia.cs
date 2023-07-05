using Core.BocaSuja.Domain.Enums;

namespace Core.BocaSuja.Domain.Entities;

public class Incidencia
{
    public Guid Id { get; private set; }
    public Guid EntidadeOfensora { get; private set; }
    public string Recurso { get; private set; }
    public TipoDeIncidenciaEnum Tipo { get; private set; }
    public int Gravidade { get; private set; }
    public string Texto { get; private set; }
    public DateTimeOffset DataHoraCriacao { get; private set; }

    public Incidencia(
        Guid entidadeOfensora, 
        string recurso,
        TipoDeIncidenciaEnum tipo,
        int gravidade,
        string texto 
    )
    {
        Id = Guid.NewGuid();
        EntidadeOfensora = entidadeOfensora;
        Recurso = recurso;
        Tipo = tipo;
        Gravidade = gravidade;
        Texto = texto;
        DataHoraCriacao = DateTimeOffset.Now;
    }
}
