using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI_Libreria.Migrations
{
    public partial class ModificarTienda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Tiendas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Tiendas");
        }
    }
}
