using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public class Team : EntityBase
{
    public int Number { get; set; }
    public List<Proyect>? Proyects { get; set; }
    public List<Employee>? Employees { get; set; }
}
