using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SegundoModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estadoImplementación",
                table: "tareas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estadoImplementación",
                table: "tareas");
        }
    }
}
