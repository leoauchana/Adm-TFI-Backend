using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfi.Data.Migrations
{
    /// <inheritdoc />
    public partial class QuintoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleados_equipos_TeamId",
                table: "empleados");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "empleados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_empleados_equipos_TeamId",
                table: "empleados",
                column: "TeamId",
                principalTable: "equipos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_empleados_equipos_TeamId",
                table: "empleados");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "empleados",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_empleados_equipos_TeamId",
                table: "empleados",
                column: "TeamId",
                principalTable: "equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
