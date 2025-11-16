namespace Tfi.Application.DTOs;

public class UserDto
{
    public record Request(string userName, string password);
    public record Response(EmployeeDto.Response employeeAuthenticated);
}
