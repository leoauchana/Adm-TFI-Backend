using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public class ChangeHistory : EntityBase
{
    public int ProyectId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime ChangeDate { get; set; }
    public string? Reason { get; set; }
    public double Budget { get; set; }
    public  Employee Employee { get; set; } = null!;
    public Proyect Proyect { get; set; } = null!;
    public List<Function>? Functions { get; set; }
}
