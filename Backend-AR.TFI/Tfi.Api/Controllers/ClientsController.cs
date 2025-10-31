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
	public async Task<IActionResult> GetAll()
	{
		return Ok(new
		{
			Message = "Clientes registrados."
		});
	}
}
