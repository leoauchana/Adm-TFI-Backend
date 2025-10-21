using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class Equipo
{
    public int IdEquipo { get; set; }

    public int NumeroEquipo { get; set; }

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
