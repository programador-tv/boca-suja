using Core.BocaSuja.Domain.Enums;

namespace Core.BocaSuja.Domain.Params;

public sealed class IncidenciaParams : EntidadeBaseParams
{
    public Guid? EntidadeOfensora { get; set; }
    public string? Recurso { get; set; }
    public TipoDeIncidencia? Tipo { get; set; }
    public int? Gravidade { get; set; }
    public string? Texto { get; set; }
}
