using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class AuthService : IAuthService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    public AuthService(IRepository repository, IMapper mapper, IConfiguration configuration)
    {
        _repository = repository;
        _mapper = mapper;
        _configuration = configuration;
    }
    public async Task<(UserDto.Response?, string)> Login(UserDto.Request userDto)
    {
        var userFound = await _repository.ObtenerElPrimero<User>(
            u => u.UserName == userDto!.userName, nameof(Employee));
        if (userFound == null || !VerifyPassword(userDto!.password!, userFound.Password!)) throw new EntityNotFoundException("El usuario o la contraseña son incorrectos");
        if (userFound.Employee == null) throw new NullException("El usuario no tiene un empleado asociado");
        return (_mapper.Map<User, UserDto.Response>(userFound), TokenGenerator(userFound));
    }
    private string TokenGenerator(User user)
    {
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Employee!.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Employee!.Name!),
            new Claim(ClaimTypes.Role, user.Employee.RolEmpleado.ToString()!)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


        var jwtConfig = new JwtSecurityToken(
            claims: userClaims,
            expires: DateTime.UtcNow.AddMinutes(10),
            signingCredentials: credentials
            );
        return new JwtSecurityTokenHandler().WriteToken(jwtConfig);
    }
    private bool VerifyPassword(string passwordInput, string hashedPassword) => BCrypt.Net.BCrypt.Verify(passwordInput, hashedPassword);
}