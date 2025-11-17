using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfi.Data.Migrations
{
    /// <inheritdoc />
    public partial class CuartoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historial_cambios_funcionalidades_FunctionId",
                table: "historial_cambios");

            migrationBuilder.DropIndex(
                name: "IX_historial_cambios_FunctionId",
                table: "historial_cambios");

            migrationBuilder.DropColumn(
                name: "FunctionId",
                table: "historial_cambios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FunctionId",
                table: "historial_cambios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_historial_cambios_FunctionId",
                table: "historial_cambios",
                column: "FunctionId");

            migrationBuilder.AddForeignKey(
                name: "FK_historial_cambios_funcionalidades_FunctionId",
                table: "historial_cambios",
                column: "FunctionId",
                principalTable: "funcionalidades",
                principalColumn: "Id");
        }
    }
}
