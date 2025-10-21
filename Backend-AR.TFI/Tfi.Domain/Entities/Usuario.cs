using System;
using System.Collections.Generic;

namespace Tfi.Domain.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ContraseniaUsuario { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }
}
