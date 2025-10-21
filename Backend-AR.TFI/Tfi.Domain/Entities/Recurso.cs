using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public partial class Recurso : EntityBase
{
    public string DescripcionRecurso { get; set; } = null!;
    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
