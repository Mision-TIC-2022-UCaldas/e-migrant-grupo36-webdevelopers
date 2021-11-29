using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Nit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PaginaWeb = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sector = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TipoServicios = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Migrantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PaisOrigen = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionActual = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Migrantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MaxMigrantes = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColaboradoraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Colaboradoras_ColaboradoraId",
                        column: x => x.ColaboradoraId,
                        principalTable: "Colaboradoras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_ColaboradoraId",
                table: "Servicios",
                column: "ColaboradoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Migrantes");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Colaboradoras");
        }
    }
}
