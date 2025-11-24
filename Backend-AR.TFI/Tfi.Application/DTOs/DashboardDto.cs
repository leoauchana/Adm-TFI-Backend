using Tfi.Domain.Entities;

namespace Tfi.Application.DTOs;

public class DashboardDto
{
    public record ResponseProgressPercentage(ProjectDto.ResponseMinimal projectData, double progressPorcentage);
    public record ResponseTeamWithPerformance(int teamNumber, int projectsCount, int numberCompletedProjects, int numberProgressdProjects);
    //public record ResponseLogChanges(ProjectDto.ResponseMinimal projectData, EmployeeDto.Response employeeData, );
}
