using Mapster;
using Tfi.Application.DTOs;
using Tfi.Domain.Entities;
using Tfi.Domain.Enum;

namespace Tfi.Application.Map;

public static class MappingConfig
{
    public static void RegisterConfig()
    {
        TypeAdapterConfig.GlobalSettings.Default
        .IgnoreNonMapped(true);

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
            .Map(dest => dest.idProject, src => src.Id)
            .Map(dest => dest.descriptionProject, src => src.Description)
            .Map(dest => dest.budgetProject, src => src.Budget)
            .Map(dest => dest.dateEnd, src => DateOnly.FromDateTime(src.DateEnd))
            .Map(dest => dest.typeProject, src => src.Type)
            .Map(dest => dest.priorityProject, src => src.Priority.ToString())
            .Map(dest => dest.stateProject, src => src.State.ToString())
            .Map(dest => dest.clientName, src => src.Client!.Name)
            .Map(dest => dest.dateInitial, src => src.DateInitial)
            .Map(dest => dest.teamNumber, src => src.Team!.Number)
            .Map(dest => dest.functions, src => src.Functions);

        TypeAdapterConfig<Proyect, ProjectDto.ResponseById>
            .NewConfig().Map(dest => dest.nameProject, src => src.Name)
            .Map(dest => dest.idProject, src => src.Id)
            .Map(dest => dest.descriptionProject, src => src.Description)
            .Map(dest => dest.budgetProject, src => src.Budget)
            .Map(dest => dest.dateEnd, src => DateOnly.FromDateTime(src.DateEnd))
            .Map(dest => dest.typeProject, src => src.Type)
            .Map(dest => dest.priorityProject, src => src.Priority.ToString())
            .Map(dest => dest.stateProject, src => src.State.ToString())
            .Map(dest => dest.client, src => src.Client)
            .Map(dest => dest.dateInitial, src => src.DateInitial)
            .Map(dest => dest.team, src => src.Team)
            .Map(dest => dest.incidencesList, src => src.Incidences)
            .Map(dest => dest.functions, src => src.Functions);

        TypeAdapterConfig<Proyect, ProjectDto.ResponseHistory>
            .NewConfig()
            .Map(dest => dest.nameProject, src => src.Name)
            .Map(dest => dest.descriptionProject, src => src.Description)
            .Map(dest => dest.budgetProject, src => src.Budget)
            .Map(dest => dest.newEndDate, src => DateOnly.FromDateTime(src.DateEnd))
            .Map(dest => dest.typeProject, src => src.Type)
            .Map(dest => dest.historyList, src => src.ChangesHistory);

        TypeAdapterConfig<Proyect, ProjectDto.ResponseMinimal>
            .NewConfig()
            .Map(dest => dest.nameProject, src => src.Name)
            .Map(dest => dest.idProject, src => src.Id)
            .Map(dest => dest.dateEnd, src => DateOnly.FromDateTime(src.DateEnd))
            .Map(dest => dest.priorityProject, src => src.Priority.ToString())
            .Map(dest => dest.stateProject, src => src.State.ToString())
            .Map(dest => dest.dateInitial, src => DateOnly.FromDateTime(src.DateInitial))
            .Map(dest => dest.teamNumber, src => src.Team!.Number);

        TypeAdapterConfig<ChangeHistory, HistoryDto.Response>
            .NewConfig()
            .Map(dest => dest.oldFunctions, src => src.Functions)
            .Map(dest => dest.oldBudget, src => src.Budget)
            .Map(dest => dest.changeDate, src => DateOnly.FromDateTime(src.ChangeDate))
            .Map(dest => dest.changeReason, src => src.Reason);

        TypeAdapterConfig<Client, ClientDto.Response>
            .NewConfig()
            .Map(dest => dest.fullNameClient, src => src.Name)
            .Map(dest => dest.mailClient, src => src.Mail)
            .Map(dest => dest.dniClient, src => src.Dni)
            .Map(dest => dest.directionClient, src => src.Direction)
            .Map(dest => dest.phoneClient, src => src.Phone);

        TypeAdapterConfig<Client, ClientDto.ResponseWithProjects>
            .NewConfig()
            .Map(dest => dest.fullNameClient, src => src.Name)
            .Map(dest => dest.mailClient, src => src.Mail)
            .Map(dest => dest.dniClient, src => src.Dni)
            .Map(dest => dest.directionClient, src => src.Direction)
            .Map(dest => dest.phoneClient, src => src.Phone)
            .Map(dest => dest.projects, src => src.Proyects);

        TypeAdapterConfig<Team, TeamDto.ResponseById>
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

        TypeAdapterConfig<TaskDto.Request, Domain.Entities.Task>
            .NewConfig()
            .Map(dest => dest.FunctionId, src => src.idFunction)
            .Map(dest => dest.Name, src => src.taskName)
            .Map(dest => dest.Description, src => src.taskDescription)
            .Map(dest => dest.Priority, src => src.taskPriority)
            .Map(dest => dest.State, src => StateProgress.In_Progress)
            .Map(dest => dest.ImplementationStatus, src => StateTask.InDevelopment)
            .Map(dest => dest.EndDate, src => src.dateEnd);

        TypeAdapterConfig<Domain.Entities.Task, TaskDto.Response>
            .NewConfig()
            .Map(dest => dest.idTask, src => src.Id)
            .Map(dest => dest.taskName, src => src.Name)
            .Map(dest => dest.taskDescription, src => src.Description)
            .Map(dest => dest.taskPriority, src => src.Priority)
            .Map(dest => dest.progressState, src => src.State.ToString())
            .Map(dest => dest.taskState, src => src.ImplementationStatus.ToString())
            .Map(dest => dest.dateEnd, src => DateOnly.FromDateTime(src.EndDate));

        TypeAdapterConfig<FunctionsDto.Request, Function>
            .NewConfig()
            .Map(dest => dest.Name, src => src.functionName)
            .Map(dest => dest.Description, src => src.functionDescription);

        TypeAdapterConfig<Function, FunctionsDto.Response>
            .NewConfig()
            .Map(dest => dest.functionName, src => src.Name)
            .Map(dest => dest.functionDescription, src => src.Description);

        TypeAdapterConfig<Function, FunctionsDto.ResponseById>
            .NewConfig()
            .Map(dest => dest.functionName, src => src.Name)
            .Map(dest => dest.functionDescription, src => src.Description)
            .Map(dest => dest.tasks, src => src.Tasks);

        TypeAdapterConfig<User, UserDto.Response>
            .NewConfig()
            .Map(dest => dest.employeeAuthenticated, src => src.Employee);

        
    }
}
