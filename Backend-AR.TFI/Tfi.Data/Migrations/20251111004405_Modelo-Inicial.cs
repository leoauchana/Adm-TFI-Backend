using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tfi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModeloInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombreCliente = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    direccionCliente = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    mailCliente = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    telefonoCliente = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroEquipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "recursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcionRecurso = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreUsuario = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    contraseniaUsuario = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    nombreProyecto = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    descripcionProyecto = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    tipoProyecto = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    estadoProyecto = table.Column<int>(type: "int", nullable: false),
                    fechaInicioPreyecto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinProyecto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    presupuestoProyecto = table.Column<double>(type: "float", nullable: false),
                    prioridadProyecto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proyectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_proyectos_clientes_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_proyectos_equipos_TeamId",
                        column: x => x.TeamId,
                        principalTable: "equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dniEmpleado = table.Column<int>(type: "int", nullable: false),
                    nombreEmpleado = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    apellidoEmpleado = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    direccionEmpleado = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    telefonoEmpleado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    mailEmpleado = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    rolEmpleado = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_empleados_equipos_TeamId",
                        column: x => x.TeamId,
                        principalTable: "equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_empleados_usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "funcionalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectId = table.Column<int>(type: "int", nullable: false),
                    nombreFuncionalidad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    descripcionFuncionalidad = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionalidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_funcionalidades_proyectos_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "incidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectId = table.Column<int>(type: "int", nullable: false),
                    tipoIncidencia = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    descripcionIncidencia = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    fechaIncidencia = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_incidencias_proyectos_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historial_cambios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProyectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    fechaCambio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivoCambio = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    presupuesto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historial_cambios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_historial_cambios_empleados_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "empleados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_historial_cambios_proyectos_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FunctionId = table.Column<int>(type: "int", nullable: false),
                    nombreTarea = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    descripcionTarea = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true),
                    prioridadTarea = table.Column<int>(type: "int", nullable: false),
                    estadoTarea = table.Column<int>(type: "int", nullable: false),
                    fechaInicioTarea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaFinTarea = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tareas_funcionalidades_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "funcionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "ResourceTask",
                columns: table => new
                {
                    ResourcesId = table.Column<int>(type: "int", nullable: false),
                    TasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTask", x => new { x.ResourcesId, x.TasksId });
                    table.ForeignKey(
                        name: "FK_ResourceTask_recursos_ResourcesId",
                        column: x => x.ResourcesId,
                        principalTable: "recursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceTask_tareas_TasksId",
                        column: x => x.TasksId,
                        principalTable: "tareas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChangeHistoryFunction_FunctionsId",
                table: "ChangeHistoryFunction",
                column: "FunctionsId");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_TeamId",
                table: "empleados",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_empleados_UserId",
                table: "empleados",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionalidades_ProyectId",
                table: "funcionalidades",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_historial_cambios_EmployeeId",
                table: "historial_cambios",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_historial_cambios_ProyectId",
                table: "historial_cambios",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_incidencias_ProyectId",
                table: "incidencias",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_ClientId",
                table: "proyectos",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_proyectos_TeamId",
                table: "proyectos",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTask_TasksId",
                table: "ResourceTask",
                column: "TasksId");

            migrationBuilder.CreateIndex(
                name: "IX_tareas_FunctionId",
                table: "tareas",
                column: "FunctionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChangeHistoryFunction");

            migrationBuilder.DropTable(
                name: "incidencias");

            migrationBuilder.DropTable(
                name: "ResourceTask");

            migrationBuilder.DropTable(
                name: "historial_cambios");

            migrationBuilder.DropTable(
                name: "recursos");

            migrationBuilder.DropTable(
                name: "tareas");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "funcionalidades");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "proyectos");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "equipos");
        }
    }
}
