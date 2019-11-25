using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGame.Migrations
{
    public partial class Riesgosdatacontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Riesgo_Games_GameId",
                table: "Riesgo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Riesgo",
                table: "Riesgo");

            migrationBuilder.RenameTable(
                name: "Riesgo",
                newName: "Riesgos");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Riesgos",
                newName: "gameId");

            migrationBuilder.RenameIndex(
                name: "IX_Riesgo_GameId",
                table: "Riesgos",
                newName: "IX_Riesgos_gameId");

            migrationBuilder.AlterColumn<int>(
                name: "gameId",
                table: "Riesgos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Riesgos",
                table: "Riesgos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riesgos_Games_gameId",
                table: "Riesgos",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Riesgos_Games_gameId",
                table: "Riesgos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Riesgos",
                table: "Riesgos");

            migrationBuilder.RenameTable(
                name: "Riesgos",
                newName: "Riesgo");

            migrationBuilder.RenameColumn(
                name: "gameId",
                table: "Riesgo",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Riesgos_gameId",
                table: "Riesgo",
                newName: "IX_Riesgo_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "Riesgo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Riesgo",
                table: "Riesgo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Riesgo_Games_GameId",
                table: "Riesgo",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
