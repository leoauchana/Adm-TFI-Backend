namespace Tfi.Application.DTOs;

public class TeamDto
{
    public record ResponseById(int numberTeam, List<EmployeeDto.Response>? employees);
    public record ResponseDashboard(int teamNumber, string projectManagerName);
}
