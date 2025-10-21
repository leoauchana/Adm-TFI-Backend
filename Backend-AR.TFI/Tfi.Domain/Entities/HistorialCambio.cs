using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class HistorialCambio
{
    public int IdHistorialCambio { get; set; }

    public int IdProyecto { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly FechaCambio { get; set; }

    public string MotivoCambio { get; set; } = null!;

    public double Presupuesto { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual ICollection<Funcionalidad> Funcionalidades { get; set; } = new List<Funcionalidad>();
}
