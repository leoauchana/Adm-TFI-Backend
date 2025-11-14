using Tfi.Domain.Common;
using Tfi.Domain.Enum;

namespace Tfi.Domain.Entities;

public class Employee : EntityBase
{
    public int Dni { get; set; }
    public string? Name { get; set; }
    public string? LastName{ get; set; }
    public string? Direction { get; set; }
    public string? Phone { get; set; }
    public string? Mail{ get; set; }
    public EmployeeRol RolEmpleado { get; set; }
    public List<ChangeHistory>? ChangesHistory { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int TeamId { get; set; }
    public Team? Team { get; set; }
}
