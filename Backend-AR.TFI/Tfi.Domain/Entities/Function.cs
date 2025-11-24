using Tfi.Domain.Common;
using Tfi.Domain.Enum;

namespace Tfi.Domain.Entities;

public class Function : EntityBase
{
    public int ProyectId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Proyect? Proyect { get; set; }
    public List<Task>? Tasks { get; set; }
    public bool IsCompleted()
    {
        return Tasks != null && Tasks.All(t => t.State == StateProgress.Completed);
    }
}
