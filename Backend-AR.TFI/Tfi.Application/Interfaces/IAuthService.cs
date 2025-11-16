using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IAuthService
{
    Task<(UserDto.Response?, string)> Login(UserDto.Request userData);
}
