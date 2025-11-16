using Tfi.Domain.Enum;

namespace Tfi.Application.DTOs;

public class TaskDto
{
    public record Request(int idFunction, string taskName, string taskDescription, Priority taskPriority, DateTime dateEnd);
    public record RequestUpdate(int idTask, StateProgress newState);
    public record Response(int idTask, string taskName, string taskDescription, Priority taskPriority, DateOnly dateEnd, DateOnly dateInitial,
        string progressState, string taskState);
}