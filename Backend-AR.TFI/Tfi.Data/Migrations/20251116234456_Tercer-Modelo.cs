using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfi.Data.Migrations
{
    /// <inheritdoc />
    public partial class TercerModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeHistoryFunction");

            migrationBuilder.AddColumn<int>(
                name: "FunctionId",
                table: "historial_cambios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "oldFunctions",
                table: "historial_cambios",
                type: "nvarchar(max)",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "oldFunctions",
                table: "historial_cambios");

            migrationBuilder.CreateTable(
                name: "ChangeHistoryFunction",
                columns: table => new
                {
                    ChangesHistoryId = table.Column<int>(type: "int", nullable: false),
                    FunctionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeHistoryFunction", x => new { x.ChangesHistoryId, x.FunctionsId });
                    table.ForeignKey(
                        name: "FK_ChangeHistoryFunction_funcionalidades_FunctionsId",
                        column: x => x.FunctionsId,
                        principalTable: "funcionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChangeHistoryFunction_historial_cambios_ChangesHistoryId",
                        column: x => x.ChangesHistoryId,
                        principalTable: "historial_cambios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeHistoryFunction_FunctionsId",
                table: "ChangeHistoryFunction",
                column: "FunctionsId");
        }
    }
}
