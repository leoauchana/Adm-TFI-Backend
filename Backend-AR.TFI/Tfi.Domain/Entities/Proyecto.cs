using Tfi.Domain.Common;
using Tfi.Domain.Enum;

namespace Tfi.Domain.Entities;

public partial class Proyecto : EntityBase
{
    public int IdEquipo { get; set; }
    public int IdCliente { get; set; }
    public string NombreProyecto { get; set; } = null!;
    public string DescripcionProyecto { get; set; } = null!;
    public string TipoProyecto { get; set; } = null!;
    public EstadoProyecto EstadoProyecto { get; set; }
    public DateOnly FechaInicioPreyecto { get; set; }
    public DateOnly FechaFinProyecto { get; set; }
    public double PresupuestoProyecto { get; set; }
    public Prioridad PrioridadProyecto { get; set; }
    public virtual ICollection<Funcionalidad> Funcionalidades { get; set; } = new List<Funcionalidad>();
    public virtual ICollection<HistorialCambio> HistorialCambios { get; set; } = new List<HistorialCambio>();
    public virtual Cliente Cliente { get; set; } = null!;
    public virtual Equipo Equipo { get; set; } = null!;
    public virtual ICollection<Incidencium> Incidencia { get; set; } = new List<Incidencium>();
}
