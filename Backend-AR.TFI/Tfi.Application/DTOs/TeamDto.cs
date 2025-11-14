namespace Tfi.Application.DTOs;

public class TeamDto
{
    public record Response(int numberTeam, List<EmployeeDto.Response>? employees);
}
