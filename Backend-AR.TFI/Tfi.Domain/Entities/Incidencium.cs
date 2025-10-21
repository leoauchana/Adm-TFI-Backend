using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class Incidencium
{
    public int IdIncidencia { get; set; }

    public int IdProyecto { get; set; }

    public string TipoIncidencia { get; set; } = null!;

    public string DescripcionIncidencia { get; set; } = null!;

    public DateOnly FechaIncidencia { get; set; }

    public virtual Proyecto Proyecto { get; set; } = null!;
}
