using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class Funcionalidad
{
    public int IdFuncionalidad { get; set; }

    public int IdProyecto { get; set; }

    public string NombreFuncionalidad { get; set; } = null!;

    public string DescripcionFuncionalidad { get; set; } = null!;

    public virtual Proyecto Proyecto { get; set; } = null!;

    public virtual ICollection<Tarea> Tareas { get; set; } = new List<Tarea>();

    public virtual ICollection<HistorialCambio> HistorialCambios { get; set; } = new List<HistorialCambio>();
}
