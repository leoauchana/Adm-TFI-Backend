using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;
    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }
    [HttpGet("getProgress")]
    [Authorize(Policy = "Administrator")]
    public async Task<IActionResult> GetProgress()
    {
        var projectsWithProgress = await _dashboardService.GetProjectsProgress();
        if (projectsWithProgress == null) return BadRequest("HUbo un error al obtener los proyectos con sus porcentajes de progreso.");
        return Ok(new
        {
            Message = "Proyectos con su progreso.",
            projectsWithProgress
        });
    }
    [HttpGet("getLoadPerTeam")]
    [Authorize(Policy = "Administrator")]
    public async Task<IActionResult> GetLoadPerTeam()
    {
        var teamWithPerfermance = await _dashboardService.GetLoadPerTeam();
        if (teamWithPerfermance == null) return BadRequest("Hubo un error al obtener el rendimiento de los equipos");
        return Ok(new
        {
            Message = "Rendimiento de equipos",
            teamWithPerfermance
        });
    }
}
