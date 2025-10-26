using Tfi.Domain.Enum;

namespace Tfi.Application.DTOs;

public class ProyectDto
{
    public record Request(int idClient, int idTeam, string nameProyect, string typeProyect, DateOnly dateEnd, 
        Prioridad priorityProyect, double budgetProyect, string descriptionProyect, List<FunctionsDto.Request> functions);
    public record Response(string nameProyect, string typeProyect, DateOnly dataInitial, DateOnly dateEnd,
        string priorityProyect, string stateProyect,double budgetProyect, string descriptionProyect,
        ClientDto.Response client, int numberTeam);
}