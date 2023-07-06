using Core.BocaSuja.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Web.Api.BocaSuja.Context.DbMapping;

public class IncidenciaDbMapping
{
    public void Build(ModelBuilder builder)
    {
        builder.Entity<Incidencia>().ToTable("Incidencias");

        builder.Entity<Incidencia>().HasKey(incidencia => incidencia.Id);

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.Id)
            .HasColumnOrder(0)
            .HasComment("Identificador Guid da incidência.")
            .IsRequired(true);

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.EntidadeOfensora)
            .HasColumnOrder(1)
            .HasColumnName("Entidade_Ofensora")
            .HasComment(
                "Indica a entidade associada à incidência, identificada por um GUID. Pode ser usada como chave estrangeira para relacionar a incidência a uma entidade específica em outra tabela."
            )
            .IsRequired(true);

        builder.Entity<Incidencia>().HasIndex(incidencia => incidencia.EntidadeOfensora);

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.Recurso)
            .HasColumnOrder(2)
            .HasColumnName("Recurso")
            .HasComment(
                "Armazena o nome ou identificador do recurso relacionado à incidência. Por exemplo, pode ser o nome de um arquivo, um URL ou qualquer outra referência ao recurso ofensivo."
            )
            .HasColumnType("nvarchar(max)")
            .IsRequired(true);

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.Tipo)
            .HasColumnOrder(3)
            .HasColumnName("Tipo")
            .HasComment(
                "Indica o tipo ou categoria da incidência. Pode ser usado para classificar as incidências de acordo com diferentes critérios. "
                    + "\"1 - Ódio\" || \"2 - Auto-Mutilação\" || \"3 - Sexual\" || \"4 - Violencia\" "
            )
            .HasColumnType("int")
            .IsRequired();

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.Gravidade)
            .HasColumnOrder(4)
            .HasColumnName("Gravidade")
            .HasComment(
                "Representa a gravidade da incidência. Pode ser usado para atribuir um valor numérico que indica o nível de severidade da incidência, como uma pontuação."
            )
            .HasColumnType("tinyint")
            .IsRequired();

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.Texto)
            .HasColumnOrder(5)
            .HasColumnName("Texto")
            .HasComment("Registra o texto que foi capturado pela incidência.")
            .HasColumnType("nvarchar(max)")
            .IsRequired();

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.DataHoraCriacao)
            .HasColumnOrder(6)
            .HasColumnName("Data_Hora_Criacao")
            .HasComment(
                "Registra a data e hora em que a incidência foi criada. É usado para rastrear o momento em que a incidência ocorreu. É mapeado como uma coluna do tipo datetimeoffset."
            )
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.DataHoraAtualizacao)
            .HasColumnOrder(7)
            .HasColumnName("Data_Hora_Atualizacao")
            .HasComment(
                "Registra a data e hora em que a incidência foi atualizada. Usado para rastrear o momento em que a incidência foi atualizada. É mapeado como uma coluna do tipo datetimeoffset."
            )
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder
            .Entity<Incidencia>()
            .Property(incidencia => incidencia.Inativo)
            .HasColumnOrder(8)
            .HasColumnName("Inativo")
            .HasComment(
                "Registra se a incidência está inativa ou não, é registrada como um valor 0 para ativo e 1 para inativo."
            )
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .IsRequired();
    }
}
