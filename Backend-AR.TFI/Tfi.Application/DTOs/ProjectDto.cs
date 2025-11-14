using Tfi.Domain.Enum;

namespace Tfi.Application.DTOs;

public class ProjectDto
{
    public record Request(int idClient, int idTeam, string nameProject, string typeProject, DateTime dateEnd, 
        Priority priorityProject, double budgetProject, string descriptionProject, List<FunctionsDto.Request> functions);
    public record RequestUpdate(int idProject, string? newDescriptionProject, int newBudgetProject);
    public record Response(string nameProject, string typeProject, DateTime dataInitial, DateTime dateEnd,
        string priorityProject, string stateProject,double budgetProject, string descriptionProject,
        ClientDto.Response client, TeamDto.Response team, List<IncidenceDto.Response>? incidencesList);
}