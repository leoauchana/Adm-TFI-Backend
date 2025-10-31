using Tfi.Domain.Enum;

namespace Tfi.Application.DTOs;

public class EmployeeDto
{
    public record Response(string nameEmployee, string lastNameEmployee, int dniEmployee, string rolEmployee);
}
