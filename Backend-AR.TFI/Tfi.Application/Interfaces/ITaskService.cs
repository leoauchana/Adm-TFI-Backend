using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface ITaskService
{
    Task<TaskDto.Response?> AddTask(TaskDto.Request taskData);
}
