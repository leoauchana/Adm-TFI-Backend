using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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
    public async Task<IActionResult> RegisterProyect([FromBody] ProyectDto.Request newProyect)
    {
        var proyectRegistered = await _proyectsService.AddProyect(newProyect);
        return Ok(new
        {
            Message = "Proyecto registrado con exito",
            proyectRegistered
        });
    }
    [HttpGet("getAllProyects")]
    public async Task<IActionResult> GetProyects()
    {
        var proyectsList = await _proyectsService.GetAll();
        if (proyectsList == null) return BadRequest("Hubo un error al obtener los proyectos.");
        return Ok(new
        {
            Message = "Proyectos registrados.",
            proyectsList
        });
    }
    [HttpGet("getById{idProyect}")]
    public async Task<IActionResult> GetById(int idProyect)
    {
        var proyect = await _proyectsService.GetById(idProyect);
        if (proyect == null) return BadRequest($"Hubo un error al obtener el proyecto de id {idProyect}");
        return Ok(new
        {
            Message = "Proyecto encontrado con exito.",
            proyect
        });
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
