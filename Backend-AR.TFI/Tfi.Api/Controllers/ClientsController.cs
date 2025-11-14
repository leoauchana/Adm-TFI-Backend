using Microsoft.AspNetCore.Mvc;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;
	public ClientsController(IClientsService clientsService)
	{
		_clientsService = clientsService;
	}
	[HttpGet("getAll")]
	public async Task<IActionResult> GetAll()
	{
		var clientsRegistered = await _clientsService.GetAll();
		if (clientsRegistered == null) return BadRequest("Hubo un error al obtener los clientes registrados.");
		return Ok(new
		{
			Message = "Clientes registrados.",
			clientsRegistered
		});
	}
}
