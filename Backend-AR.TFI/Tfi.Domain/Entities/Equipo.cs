using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public partial class Equipo : EntityBase
{
    public int NumeroEquipo { get; set; }

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
