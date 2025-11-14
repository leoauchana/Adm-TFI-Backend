using Tfi.Domain.Common;
using Tfi.Domain.Enum;

namespace Tfi.Domain.Entities;

public class Proyect : EntityBase
{
    public int TeamId { get; set; }
    public int ClientId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; } 
    public StateProgress State { get; set; }
    public DateTime DateInitial { get; set; }
    public DateTime DateEnd { get; set; }
    public double Budget { get; set; }
    public Priority Priority { get; set; }
    public List<Function>? Functions { get; set; }
    public List<ChangeHistory>? ChangesHistory { get; set; }
    public Client? Client { get; set; }
    public Team? Team { get; set; }
    public List<Incidence>? Incidences { get; set; }
}
