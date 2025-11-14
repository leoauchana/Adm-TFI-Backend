using Microsoft.AspNetCore.Mvc;
using Tfi.Application.DTOs;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProyectsService _proyectsService;
    public ProjectsController(IProyectsService proyectsService)
    {
        _proyectsService = proyectsService;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterProyect([FromBody] ProjectDto.Request newProyect)
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
    [HttpGet("getById/{idProyect}")]
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

    [HttpPatch("deleteProyect/{idProyect}")]
    public async Task<IActionResult> DeleteProyect(int idProyect)
    {
        var proyectDeleted = await _proyectsService.DeleteProyect(idProyect);
        if (proyectDeleted == null) return BadRequest("Hubo un error al dar de baja el proyecto.");
        return Ok(new
        {
            Message = "Proyecto dado de baja exitosamente.",
            proyectDeleted
        });
    }

    [HttpPatch("updateProyect")]
    public async Task<IActionResult> UpdateProyect([FromBody] ProjectDto.RequestUpdate proyectData)
    {
        var proyectUpdated = await _proyectsService.UpdateProyect(proyectData);
        if (proyectUpdated == null) return BadRequest("Hubo un error al actualizar el proyecto.");
        return Ok(new
        {
            Message = "Proyecto modificado con éxito.",
            proyectUpdated
        });
    }
}
