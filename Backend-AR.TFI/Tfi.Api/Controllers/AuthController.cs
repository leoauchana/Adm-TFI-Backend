using Microsoft.AspNetCore.Mvc;
using Tfi.Application.DTOs;
using Tfi.Application.Interfaces;

namespace Tfi.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    public async Task<IActionResult> Login([FromBody] UserDto.Request userData)
    {
        var userAuthenticated = await _authService.Login(userData);
        if (userAuthenticated == null) return BadRequest("Hubo un error al iniciar sesión.");
        return Ok(new
        {
            Message = "Inicio de sesión correcto",
            userAuthenticated
        });
    }
}
