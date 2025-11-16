using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tfi.Application.DTOs;
using Tfi.Application.Interfaces;
using Tfi.Application.Services;

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
	[Authorize(Policy = "Administrator")]
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
    [Authorize(Policy = "Administrator")]
    [HttpGet("getByIdWithProjects/{idClient}")]
    public async Task<IActionResult> GetByIdWithProjects(int idClient)
    {
        var clientFound = await _clientsService.GetByIdWithProjects(idClient);
        if (clientFound == null) return BadRequest("Hubo un error al obtener los clientes registrados.");
        return Ok(new
        {
            Message = "Clientes registrado con sus projectos",
            clientFound
        });
    }
}
