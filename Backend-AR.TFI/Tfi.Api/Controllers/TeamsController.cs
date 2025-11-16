using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
	private readonly ITeamsService _teamsService;
	public TeamsController(ITeamsService teamsService)
	{
		_teamsService = teamsService;
	}
	[HttpGet]
	[Authorize(Policy = "Administrator")]
	public async Task<IActionResult> GetAll()
	{
		var teamsRegistered = await _teamsService.GetAll();
		if (teamsRegistered == null) return BadRequest("Hubo un error al obtener los equipos de desarrollo.");
		return Ok(new
		{
			Message = "Equipos registrados.",
			teamsRegistered
		});
	}
}
