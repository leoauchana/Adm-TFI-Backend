using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public partial class Cliente : EntityBase
{
    public int Dni { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string DireccionCliente { get; set; } = null!;

    public string TipoCliente { get; set; } = null!;

    public string MailCliente { get; set; } = null!;

    public string TelefonoCliente { get; set; } = null!;

    public virtual ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
}
