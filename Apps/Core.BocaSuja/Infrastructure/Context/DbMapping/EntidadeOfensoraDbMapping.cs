using Core.BocaSuja.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.BocaSuja.Infrastructure.Context.DbMapping;

public sealed class EntidadeOfensoraDbMapping
{
    public void Build(ModelBuilder builder)
    {
        builder.Entity<EntidadeOfensora>().ToTable("Entidades Ofensoras");

        builder.Entity<EntidadeOfensora>().HasKey(entidade => entidade.Id);

        builder
            .Entity<EntidadeOfensora>()
            .Property(entidade => entidade.Id)
            .HasColumnOrder(0)
            .HasComment("Identificador Guid da entidade ofensora.")
            .IsRequired(true);

        builder
            .Entity<EntidadeOfensora>()
            .Property(entidade => entidade.ApelidoEntidade)
            .HasColumnOrder(1)
            .HasColumnName("Apelido_Entidade")
            .HasComment("Indica o alias/apelido da entidade.")
            .IsRequired(true);

        builder.Entity<EntidadeOfensora>().HasIndex(entidade => entidade.ApelidoEntidade);

        builder
            .Entity<EntidadeOfensora>()
            .Property(entidade => entidade.DataHoraCriacao)
            .HasColumnOrder(2)
            .HasColumnName("Data_Hora_Criacao")
            .HasComment(
                "Registra a data e hora em que a entidade foi criada. É usado para rastrear o momento em que a entidade ocorreu. É mapeado como uma coluna do tipo datetimeoffset."
            )
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder
            .Entity<EntidadeOfensora>()
            .Property(entidade => entidade.DataHoraAtualizacao)
            .HasColumnOrder(3)
            .HasColumnName("Data_Hora_Atualizacao")
            .HasComment(
                "Registra a data e hora em que a entidade foi atualizada. Usado para rastrear o momento em que a entidade foi atualizada. É mapeado como uma coluna do tipo datetimeoffset."
            )
            .HasColumnType("datetimeoffset")
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("SYSUTCDATETIME()")
            .IsRequired();

        builder
            .Entity<EntidadeOfensora>()
            .Property(entidade => entidade.Inativo)
            .HasColumnOrder(4)
            .HasColumnName("Inativo")
            .HasComment(
                "Registra se a entidade está inativa ou não, é registrada como um valor 0 para ativo e 1 para inativo."
            )
            .HasColumnType("bit")
            .HasDefaultValue(false)
            .IsRequired();
    }
}
