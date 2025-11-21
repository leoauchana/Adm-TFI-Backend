using Tfi.Domain.Common;
using Tfi.Domain.Enum;

namespace Tfi.Domain.Entities;

public class Task : EntityBase
{
    public Task()
    {
        Resources = new List<Resource>();
    }
    public int FunctionId { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; }
    public Priority Priority { get; set; }
    public StateProgress State { get; set; }
    public StateTask ImplementationStatus { get; set; }
    public DateTime InitialDate { get; set; }
    public DateTime EndDate { get; set; }
    public Function? Function { get; set; }
    public List<Resource>? Resources { get; set; }
}
