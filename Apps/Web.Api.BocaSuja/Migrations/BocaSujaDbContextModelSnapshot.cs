﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web.Api.BocaSuja.Configuration.Context;

#nullable disable

namespace Web.Api.BocaSuja.Migrations
{
    [DbContext(typeof(BocaSujaDbContext))]
    partial class BocaSujaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.BocaSuja.Domain.Entities.Incidencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnOrder(0)
                        .HasComment("Identificador Guid da incidência.");

                    b.Property<DateTimeOffset>("DataHoraCriacao")
                        .HasColumnType("datetimeoffset")
                        .HasColumnName("Data_Hora_Criacao")
                        .HasColumnOrder(5)
                        .HasComment("Registra a data e hora em que a incidência foi criada. É usado para rastrear o momento em que a incidência ocorreu. É mapeado como uma coluna do tipo datetimeoffset.");

                    b.Property<Guid>("EntidadeOfensora")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Entidade_Ofensora")
                        .HasColumnOrder(1)
                        .HasComment("Indica a entidade associada à incidência, identificada por um GUID. Pode ser usada como chave estrangeira para relacionar a incidência a uma entidade específica em outra tabela.");

                    b.Property<byte>("Gravidade")
                        .HasColumnType("tinyint")
                        .HasColumnName("Gravidade")
                        .HasColumnOrder(4)
                        .HasComment("Representa a gravidade da incidência. Pode ser usado para atribuir um valor numérico que indica o nível de severidade da incidência, como uma pontuação.");

                    b.Property<string>("Recurso")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Recurso")
                        .HasColumnOrder(2)
                        .HasComment("Armazena o nome ou identificador do recurso relacionado à incidência. Por exemplo, pode ser o nome de um arquivo, um URL ou qualquer outra referência ao recurso ofensivo.");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Tipo")
                        .HasColumnOrder(3)
                        .HasComment("Indica o tipo ou categoria da incidência. Pode ser usado para classificar as incidências de acordo com diferentes critérios.");

                    b.HasKey("Id");

                    b.HasIndex("EntidadeOfensora");

                    b.ToTable("Incidencias", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
