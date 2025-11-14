using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public class Client : EntityBase
{
    public int Dni { get; set; }
    public string? Name { get; set; }
    public string? Direction{ get; set; }
    public string? Mail { get; set; }
    public string? Phone { get; set; } = null!;
    public List<Proyect>? Proyects { get; set; }
}
