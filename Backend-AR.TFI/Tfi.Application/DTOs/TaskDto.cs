using Tfi.Domain.Enum;

namespace Tfi.Application.DTOs;

public class TaskDto
{
    public record Request(int idFunction, string taskName, string taskDescription, Priority taskPriority, DateTime dateEnd);
    public record Response();
}
