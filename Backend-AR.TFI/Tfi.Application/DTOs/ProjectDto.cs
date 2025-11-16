using Tfi.Domain.Enum;

namespace Tfi.Application.DTOs;

public class ProjectDto
{
    public record Request(int idClient, int idTeam, string nameProject, string typeProject, DateTime dateEnd, 
        Priority priorityProject, double budgetProject, string descriptionProject, List<FunctionsDto.Request> functions);
    public record RequestUpdate(int idProject, string? newDescriptionProject, double newBudgetProject, DateTime dateEnd,
        string changeReason, List<FunctionsDto.Request> newFunctions);
    public record Response(int idProject, string nameProject, string typeProject, DateTime dateInitial, DateOnly dateEnd,
        string priorityProject, string stateProject, double budgetProject, string descriptionProject,
        string clientName, int teamNumber,
        List<FunctionsDto.Response>? functions);
    public record ResponseById(int idProject, string nameProject, string typeProject, DateTime dateInitial, DateOnly dateEnd,
        string priorityProject, string stateProject, double budgetProject, string descriptionProject,
        ClientDto.Response client, TeamDto.ResponseById team, List<IncidenceDto.Response>? incidencesList,
        List<FunctionsDto.ResponseById>? functions);
    public record ResponseHistory(string nameProject, string typeProject, double budgetProject, string descriptionProject,
        DateOnly newEndDate, List<HistoryDto.Response> historyList);
    public record ResponseMinimal(int idProject, string nameProject, DateTime dateInitial, DateOnly dateEnd,
        string priorityProject, string stateProject, int teamNumber);
}