using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Migrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DireccionActual = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migrantes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Migrantes");
        }
    }
}
