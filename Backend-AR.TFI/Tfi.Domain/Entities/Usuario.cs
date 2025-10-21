using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public partial class Usuario : EntityBase
{
    public string NombreUsuario { get; set; } = null!;

    public string ContraseniaUsuario { get; set; } = null!;

    public virtual Empleado? Empleado { get; set; }
}
