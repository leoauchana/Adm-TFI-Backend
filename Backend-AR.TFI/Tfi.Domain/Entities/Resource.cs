using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public class Resource : EntityBase
{
    public string? Description { get; set; }
    public List<Task>? Tasks { get; set; }
}
