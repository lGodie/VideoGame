using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGame.Migrations
{
    public partial class Desarrollador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpcionesMejoras_Games_GameId",
                table: "OpcionesMejoras");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "OpcionesMejoras",
                newName: "gameId");

            migrationBuilder.RenameIndex(
                name: "IX_OpcionesMejoras_GameId",
                table: "OpcionesMejoras",
                newName: "IX_OpcionesMejoras_gameId");

            migrationBuilder.AlterColumn<int>(
                name: "gameId",
                table: "OpcionesMejoras",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Desarrolladores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desarrolladores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desarrolladores_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desarrolladores_UserId",
                table: "Desarrolladores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_OpcionesMejoras_Games_gameId",
                table: "OpcionesMejoras",
                column: "gameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpcionesMejoras_Games_gameId",
                table: "OpcionesMejoras");

            migrationBuilder.DropTable(
                name: "Desarrolladores");

            migrationBuilder.RenameColumn(
                name: "gameId",
                table: "OpcionesMejoras",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_OpcionesMejoras_gameId",
                table: "OpcionesMejoras",
                newName: "IX_OpcionesMejoras_GameId");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "OpcionesMejoras",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OpcionesMejoras_Games_GameId",
                table: "OpcionesMejoras",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
