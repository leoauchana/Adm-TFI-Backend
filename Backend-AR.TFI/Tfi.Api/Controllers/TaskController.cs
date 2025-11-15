using Microsoft.AspNetCore.Mvc;
using Tfi.Application.DTOs;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    [HttpPost]
    public async Task<IActionResult> RegisterTask([FromBody] TaskDto.Request taskData)
    {
        var taskRegistered = await _taskService.AddTask(taskData);
        if (taskRegistered == null) return BadRequest("Hubo un error al registrar la tarea.");
        return Ok(new {
            Message = "Tarea registrada con éxito.",
            taskRegistered
        });
    }
}
