using Tfi.Domain.Common;
using Tfi.Domain.Enum;

namespace Tfi.Domain.Entities;

public partial class Tarea : EntityBase
{
    public int IdEmpleado { get; set; }

    public int IdFuncionalidad { get; set; }

    public string NombreTarea { get; set; } = null!;

    public string DescripcionTarea { get; set; } = null!;

    public Prioridad PrioridadTarea { get; set; }

    public EstadoAvance EstadoTarea { get; set; };

    public DateOnly FechaInicioTarea { get; set; }

    public DateOnly FechaFinTarea { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual Funcionalidad Funcionalidad { get; set; } = null!;

    public virtual ICollection<Recurso> Recursos { get; set; } = new List<Recurso>();
}
