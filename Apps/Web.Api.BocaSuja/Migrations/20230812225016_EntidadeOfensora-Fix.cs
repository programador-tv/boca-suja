using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Api.BocaSuja.Migrations
{
    /// <inheritdoc />
    public partial class EntidadeOfensoraFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entidades Ofensoras",
                columns: table =>
                    new
                    {
                        Id = table.Column<Guid>(
                            type: "uniqueidentifier",
                            nullable: false,
                            comment: "Identificador Guid da entidade ofensora."
                        ),
                        Apelido_Entidade = table.Column<string>(
                            type: "nvarchar(450)",
                            nullable: false,
                            comment: "Indica o alias/apelido da entidade."
                        ),
                        Data_Hora_Criacao = table.Column<DateTimeOffset>(
                            type: "datetimeoffset",
                            nullable: false,
                            defaultValueSql: "SYSUTCDATETIME()",
                            comment: "Registra a data e hora em que a entidade foi criada. É usado para rastrear o momento em que a entidade ocorreu. É mapeado como uma coluna do tipo datetimeoffset."
                        ),
                        Data_Hora_Atualizacao = table.Column<DateTimeOffset>(
                            type: "datetimeoffset",
                            nullable: false,
                            defaultValueSql: "SYSUTCDATETIME()",
                            comment: "Registra a data e hora em que a entidade foi atualizada. Usado para rastrear o momento em que a entidade foi atualizada. É mapeado como uma coluna do tipo datetimeoffset."
                        ),
                        Inativo = table.Column<bool>(
                            type: "bit",
                            nullable: false,
                            defaultValue: false,
                            comment: "Registra se a entidade está inativa ou não, é registrada como um valor 0 para ativo e 1 para inativo."
                        )
                    },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades Ofensoras", x => x.Id);
                }
            );

            migrationBuilder.CreateIndex(
                name: "IX_Entidades Ofensoras_Apelido_Entidade",
                table: "Entidades Ofensoras",
                column: "Apelido_Entidade"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Entidades Ofensoras");
        }
    }
}
