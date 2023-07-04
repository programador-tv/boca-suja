namespace Core.BocaSuja.Domain.Entities;
public class Incidencia
{
  public Guid Id { get; private set; }
  public Guid EntidadeOfensora { get; private set; }
  public string Recurso { get; private set; }
  public string Tipo { get; private set; }
  public int Gravidade { get; private set; }
  public DateTimeOffset DataHoraCriacao { get; private set; }

  public Incidencia(Guid entidadeOfensora, string recurso, string tipo, int gravidade)
  {
    Id = Guid.NewGuid();
    EntidadeOfensora = entidadeOfensora;
    Recurso = recurso;
    Tipo = tipo;
    Gravidade = gravidade;
    DataHoraCriacao = DateTimeOffset.Now;
  }
}
