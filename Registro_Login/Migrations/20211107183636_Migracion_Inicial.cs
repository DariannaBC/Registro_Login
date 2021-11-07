using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registro_Login.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    PermisosId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    DescripcionPermisos = table.Column<string>(type: "TEXT", nullable: true),
                    VecesAsignado = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.PermisosId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescripcionRol = table.Column<string>(type: "TEXT", nullable: true),
                    EsActivo = table.Column<bool>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Clave = table.Column<string>(type: "TEXT", nullable: true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FechaIngreso = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DescripcionRol = table.Column<string>(type: "TEXT", nullable: true),
                    Alias = table.Column<string>(type: "TEXT", nullable: true),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "RolesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RolID = table.Column<int>(type: "INTEGER", nullable: false),
                    PermisosId = table.Column<int>(type: "INTEGER", nullable: false),
                    EsAsignado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolesDetalle_Roles_RolID",
                        column: x => x.RolID,
                        principalTable: "Roles",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisosId", "DescripcionPermisos", "Nombre", "VecesAsignado" },
                values: new object[] { 1, "Con este permiso es posible modificar el precio", "Descuento", 0 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisosId", "DescripcionPermisos", "Nombre", "VecesAsignado" },
                values: new object[] { 2, "Con este permiso es posible vender", "Vende", 0 });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "PermisosId", "DescripcionPermisos", "Nombre", "VecesAsignado" },
                values: new object[] { 3, "Con este permiso es posible comprar", "Compra", 0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolID", "DescripcionRol", "EsActivo", "FechaCreacion" },
                values: new object[] { 1, "Con este permiso es posible modificar el precio", false, new DateTime(2021, 11, 7, 14, 36, 32, 764, DateTimeKind.Local).AddTicks(9319) });

            migrationBuilder.CreateIndex(
                name: "IX_RolesDetalle_RolID",
                table: "RolesDetalle",
                column: "RolID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "RolesDetalle");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
