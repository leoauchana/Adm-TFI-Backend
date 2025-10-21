using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public partial class Funcionalidad : EntityBase
{
    public int IdProyecto { get; set; }

    public string NombreFuncionalidad { get; set; } = null!;

    public string DescripcionFuncionalidad { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    public virtual ICollection<HistorialCambio> HistorialCambios { get; set; } = new List<HistorialCambio>();
}
