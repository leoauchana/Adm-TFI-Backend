using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public int IdUsuario { get; set; }

    public int DniEmpleado { get; set; }

    public string NombreEmpleado { get; set; } = null!;

    public string ApellidoEmpleado { get; set; } = null!;

    public string DireccionEmpleado { get; set; } = null!;

    public string TelefonoEmpleado { get; set; } = null!;

    public string MailEmpleado { get; set; } = null!;

    public int RolEmpleado { get; set; }

    public virtual ICollection<HistorialCambio> HistorialCambios { get; set; } = new List<HistorialCambio>();

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    public virtual ICollection<Equipo> Equipos { get; set; } = new List<Equipo>();
}
