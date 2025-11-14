using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public class Incidence : EntityBase
{
    public int ProyectId { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public DateTime? RegisterDate { get; set; }
    public Proyect? Proyect { get; set; }
}
