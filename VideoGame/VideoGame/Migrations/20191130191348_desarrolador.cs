using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGame.Migrations
{
    public partial class desarrolador : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Desarrolladores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Desarrolladores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Desarrolladores",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Desarrolladores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cargo",
                table: "Desarrolladores",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DesarrolladorViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Apellido = table.Column<string>(nullable: true),
                    cargo = table.Column<string>(nullable: true),
                    Genero = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesarrolladorViewModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DesarrolladorViewModel");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Desarrolladores");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Desarrolladores");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Desarrolladores");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Desarrolladores");

            migrationBuilder.DropColumn(
                name: "cargo",
                table: "Desarrolladores");
        }
    }
}
