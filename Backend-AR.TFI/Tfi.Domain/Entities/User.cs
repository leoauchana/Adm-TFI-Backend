using Tfi.Domain.Common;

namespace Tfi.Domain.Entities;

public class User : EntityBase
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public virtual Employee? Employee { get; set; }
}
