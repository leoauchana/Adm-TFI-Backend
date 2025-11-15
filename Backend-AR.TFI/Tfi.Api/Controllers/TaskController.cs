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
    [HttpPatch("deleteTask/{idTask}")]
    public async Task<IActionResult> DeleteTask(int idTask)
    {
        var isSuccess = await _taskService.DeleteTask(idTask);
        if (!isSuccess) return BadRequest("Hubo un error al dar de baja el proyecto.");
        return Ok(new
        {
            Message = "Tarea dada de baja exitosamente.",
        });
    }

    [HttpPatch("completeTask/{idTask}")]
    public async Task<IActionResult> CompleteTask(int idTask)
    {
        var isSuccess = await _taskService.CompleteTask(idTask);
        if (!isSuccess) return BadRequest("Hubo un error al actualizar el proyecto.");
        return Ok(new
        {
            Message = "Tarea modifcado al estado completada con éxito.",
        });
    }
}
