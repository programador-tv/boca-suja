using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Api.BocaSuja.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identificador Guid da incidência."),
                    Entidade_Ofensora = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Indica a entidade associada à incidência, identificada por um GUID. Pode ser usada como chave estrangeira para relacionar a incidência a uma entidade específica em outra tabela."),
                    Recurso = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Armazena o nome ou identificador do recurso relacionado à incidência. Por exemplo, pode ser o nome de um arquivo, um URL ou qualquer outra referência ao recurso ofensivo."),
                    Tipo = table.Column<string>(type: "nvarchar(50)", nullable: false, comment: "Indica o tipo ou categoria da incidência. Pode ser usado para classificar as incidências de acordo com diferentes critérios."),
                    Gravidade = table.Column<byte>(type: "tinyint", nullable: false, comment: "Representa a gravidade da incidência. Pode ser usado para atribuir um valor numérico que indica o nível de severidade da incidência, como uma pontuação."),
                    Data_Hora_Criacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "Registra a data e hora em que a incidência foi criada. É usado para rastrear o momento em que a incidência ocorreu. É mapeado como uma coluna do tipo datetimeoffset.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_Entidade_Ofensora",
                table: "Incidencias",
                column: "Entidade_Ofensora");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidencias");
        }
    }
}
