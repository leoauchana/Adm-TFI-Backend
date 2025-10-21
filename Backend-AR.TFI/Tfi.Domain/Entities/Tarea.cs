using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public int IdEmpleado { get; set; }

    public int IdFuncionalidad { get; set; }

    public string NombreTarea { get; set; } = null!;

    public string DescripcionTarea { get; set; } = null!;

    public string PrioridadTarea { get; set; } = null!;

    public string EstadoTarea { get; set; } = null!;

    public DateOnly FechaInicioTarea { get; set; }

    public DateOnly FechaFinTarea { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Funcionalidad Funcionalidad { get; set; } = null!;

    public virtual ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
}
