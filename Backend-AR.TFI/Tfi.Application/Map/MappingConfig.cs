using Mapster;
using Tfi.Application.DTOs;
using Tfi.Domain.Entities;
using Tfi.Domain.Enum;

namespace Tfi.Application.Map;

public static class MappingConfig
{
    public static void RegisterConfig()
    {
        TypeAdapterConfig<FunctionsDto.Request, Function>
            .NewConfig()
            .Map(dest => dest.Name, src => src.functionName)
            .Map(dest => dest.Description, src => src.functionDescription);

        TypeAdapterConfig<ProjectDto.Request, Proyect>
            .NewConfig()
            .Map(dest => dest.Name, src => src.nameProject)
            .Map(dest => dest.Description, src => src.descriptionProject)
            .Map(dest => dest.Budget, src => src.budgetProject)
            .Map(dest => dest.DateEnd, src => src.dateEnd)
            .Map(dest => dest.Type, src => src.typeProject)
            .Map(dest => dest.Priority, src => src.priorityProject)
            .Map(dest => dest.State, src => StateProgress.In_Progress)
            .Map(dest => dest.ClientId, src => src.idClient)
            .Map(dest => dest.TeamId, src => src.idTeam)
            .Map(dest => dest.DateInitial, src => DateTime.UtcNow)
            .Map(dest => dest.Functions, src => src.functions);

        TypeAdapterConfig<Proyect, ProjectDto.Response>
            .NewConfig().Map(dest => dest.nameProject, src => src.Name)
            .Map(dest => dest.descriptionProject, src => src.Description)
            .Map(dest => dest.budgetProject, src => src.Budget)
            .Map(dest => dest.dateEnd, src => src.DateEnd)
            .Map(dest => dest.typeProject, src => src.Type)
            .Map(dest => dest.priorityProject, src => src.Priority.ToString())
            .Map(dest => dest.stateProject, src => src.State.ToString())
            .Map(dest => dest.client, src => src.Client)
            .Map(dest => dest.dataInitial, src => src.DateInitial)
            .Map(dest => dest.client, src => src.Client)
            .Map(dest => dest.team, src => src.Team)
            .Map(dest => dest.incidencesList, src => src.Incidences);

        TypeAdapterConfig<Client, ClientDto.Response>
            .NewConfig()
            .Map(dest => dest.fullNameClient, src => src.Name)
            .Map(dest => dest.mailClient, src => src.Mail)
            .Map(dest => dest.dniClient, src => src.Dni)
            .Map(dest => dest.directionClient, src => src.Direction)
            .Map(dest => dest.phoneClient, src => src.Phone);

        TypeAdapterConfig<Team, TeamDto.Response>
            .NewConfig()
            .Map(dest => dest.numberTeam, src => src.Number)
            .Map(dest => dest.employees, src => src.Employees);

        TypeAdapterConfig<Employee, EmployeeDto.Response>
            .NewConfig()
            .Map(dest => dest.nameEmployee, src => src.Name)
            .Map(dest => dest.lastNameEmployee, src => src.LastName)
            .Map(dest => dest.dniEmployee, src => src.Dni)
            .Map(dest => dest.rolEmployee, src => src.RolEmpleado.ToString());

        TypeAdapterConfig<IncidenceDto.Request, Incidence>
            .NewConfig()
            .Map(dest => dest.Description, src => src.descriptionIncidence)
            .Map(dest => dest.Type, src => src.typeIncidence)
            .Map(dest => dest.ProyectId, src => src.idProyect)
            .Map(dest => dest.RegisterDate, src => DateTime.UtcNow);

        TypeAdapterConfig<Incidence, IncidenceDto.Response>
            .NewConfig()
            .Map(dest => dest.descriptionIncidence, src => src.Description)
            .Map(dest => dest.typeIncidence, src => src.Type);
    }
}
