using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace T2S.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conteiner",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cliente = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Tipo = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Categoria = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TipoMovimentacao = table.Column<string>(nullable: true),
                    DataHoraInicio = table.Column<DateTime>(nullable: false),
                    DataHoraFim = table.Column<DateTime>(nullable: false),
                    ConteinerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Conteiner_ConteinerId",
                        column: x => x.ConteinerId,
                        principalTable: "Conteiner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Conteiner",
                columns: new[] { "Id", "Numero", "Categoria", "Cliente", "Status", "Tipo" },
                values: new object[] { new Guid("ec55c247-7fbd-4af1-8c7f-ef7a461840ee"), "TEST1234567", "Importação", "Claudio Marcio", "Cheio", 40 });

            migrationBuilder.InsertData(
                table: "Conteiner",
                columns: new[] { "Id", "Numero", "Categoria", "Cliente", "Status", "Tipo" },
                values: new object[] { new Guid("233caf54-fbc2-432f-8272-d2d8338738d5"), "TEST1234568", "Exportação", "João Luiz", "Vazio", 20 });

            migrationBuilder.InsertData(
                table: "Movimentacao",
                columns: new[] { "Id", "ConteinerId", "DataHoraFim", "DataHoraInicio", "TipoMovimentacao" },
                values: new object[] { new Guid("be82c97b-f3f3-4eb9-9669-bb54dde45a24"), new Guid("ec55c247-7fbd-4af1-8c7f-ef7a461840ee"), new DateTime(2021, 7, 8, 11, 55, 34, 565, DateTimeKind.Local).AddTicks(425), new DateTime(2021, 7, 8, 11, 55, 34, 561, DateTimeKind.Local).AddTicks(7745), "Embarque" });

            migrationBuilder.InsertData(
                table: "Movimentacao",
                columns: new[] { "Id", "ConteinerId", "DataHoraFim", "DataHoraInicio", "TipoMovimentacao" },
                values: new object[] { new Guid("6a08d48c-4d39-4732-a5ba-ac05097f5904"), new Guid("ec55c247-7fbd-4af1-8c7f-ef7a461840ee"), new DateTime(2021, 7, 8, 11, 55, 34, 575, DateTimeKind.Local).AddTicks(9379), new DateTime(2021, 7, 8, 11, 55, 34, 575, DateTimeKind.Local).AddTicks(9250), "Descarga" });

            migrationBuilder.InsertData(
                table: "Movimentacao",
                columns: new[] { "Id", "ConteinerId", "DataHoraFim", "DataHoraInicio", "TipoMovimentacao" },
                values: new object[] { new Guid("40b96cba-3edb-49e4-9962-1dfdce2687f1"), new Guid("233caf54-fbc2-432f-8272-d2d8338738d5"), new DateTime(2021, 7, 8, 11, 55, 34, 577, DateTimeKind.Local).AddTicks(9286), new DateTime(2021, 7, 8, 11, 55, 34, 577, DateTimeKind.Local).AddTicks(9238), "Embarque" });

            migrationBuilder.InsertData(
                table: "Movimentacao",
                columns: new[] { "Id", "ConteinerId", "DataHoraFim", "DataHoraInicio", "TipoMovimentacao" },
                values: new object[] { new Guid("912ccc62-3749-47a9-b77d-c7f9a8dccd82"), new Guid("233caf54-fbc2-432f-8272-d2d8338738d5"), new DateTime(2021, 7, 8, 11, 55, 34, 578, DateTimeKind.Local).AddTicks(499), new DateTime(2021, 7, 8, 11, 55, 34, 578, DateTimeKind.Local).AddTicks(483), "Descarga" });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_ConteinerId",
                table: "Movimentacao",
                column: "ConteinerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Conteiner");
        }
    }
}
