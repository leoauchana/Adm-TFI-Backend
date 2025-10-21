using Microsoft.AspNetCore.Mvc;
using Tfi.Application.DTOs;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProyectsController : ControllerBase
{
    private readonly IProyectsService _proyectsService;
    public ProyectsController(IProyectsService proyectsService)
    {
        _proyectsService = proyectsService;
    }

    [HttpPost]
    public IActionResult RegisterProyect([FromBody] ProyectDto.Request request)
    {
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetProyects()
    {
        return Ok();
    }

    [HttpDelete("deleteProyect{id}")]
    public IActionResult DeleteProyect(int id)
    {
        return BadRequest();
    }

    [HttpPut("updateProyect{id}")]
    public IActionResult UpdateProyect(int id)
    {
        return BadRequest();
    }

}
