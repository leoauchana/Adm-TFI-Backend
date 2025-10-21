using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class Recurso
{
    public int IdRecurso { get; set; }

    public string DescripcionRecurso { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();
}
