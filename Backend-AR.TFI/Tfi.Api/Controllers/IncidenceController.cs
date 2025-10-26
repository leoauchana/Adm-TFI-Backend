using Microsoft.AspNetCore.Mvc;
using Tfi.Application.DTOs;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IncidenceController : ControllerBase
{
	private readonly IIncidencesService _incidencesService;
	public IncidenceController(IIncidencesService incidencesService)
	{
		_incidencesService = incidencesService;
	}
	[HttpGet("getAllIncidendes{idProyect}")]
	public async Task<IActionResult> GetIncidences(int idProyect)
	{
		var incidencesRegistered = await _incidencesService.GetIncidences(idProyect);
		if (incidencesRegistered == null) return BadRequest($"Error al obtener las incidencias del proyecto con id{idProyect}.");
		return Ok(new
		{
			Message = "Incidencias registradas.",
			incidencesRegistered
		});
	}
	[HttpPost]
	public async Task<IActionResult> AddIncidencias([FromBody] IncidenceDto.Request incidenceRequest)
	{
		var newIncidence = await _incidencesService.RegisterIncidence(incidenceRequest);
		if (newIncidence == null) return BadRequest("Error al registrar la incidencia.");
		return Ok(new
		{
			Message = "Incidencia registrada con exito.",
			newIncidence
		});
	}
}
