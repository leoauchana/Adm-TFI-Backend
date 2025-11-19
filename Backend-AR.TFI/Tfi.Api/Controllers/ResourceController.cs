using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResourceController : ControllerBase
{
    private readonly IResourcesService _resourcesService;
    public ResourceController(IResourcesService resourcesService)
    {
        _resourcesService = resourcesService;
    }
    [HttpGet]
    [Authorize(Policy = "ProjectManager")]
    public async Task<IActionResult> GetAll()
    {
        var resourcesList = await _resourcesService.GetAll();
        if (resourcesList == null) return BadRequest("Hubo un error al obtener los recursos.");
        return Ok(new
        {
            Message = "Recursos registrados.",
            resourcesList
        });
    }
}
