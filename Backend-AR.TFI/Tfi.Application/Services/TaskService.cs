using MapsterMapper;
using System.Threading.Tasks;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Enum;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class TaskService : ITaskService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;
    public TaskService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<TaskDto.Response?> AddTask(TaskDto.Request taskData)
    {
        var functionFound = await _repository.ObtenerPorId<Function>(taskData.idFunction);
        if (functionFound == null) throw new EntityNotFoundException($"La funcion de id {taskData.idFunction} no se encontró.");
        var newTask = _mapper.Map<TaskDto.Request, Domain.Entities.Task>(taskData);
        var resources = await _repository.ListarTodos<Resource>();
        newTask.Resources!.AddRange(resources.Where(r => taskData.resourceList.Contains(r.Id)).ToList());
        await _repository.Agregar(newTask);
        return _mapper.Map<Domain.Entities.Task, TaskDto.Response>(newTask);
    }
    public async Task<bool> CompleteTask(int idTask, string idEmployee)
    {
        var employeeFound = await _repository.ObtenerPorId<Employee>(int.Parse(idEmployee));
        if (employeeFound == null) throw new EntityNotFoundException($"El empleado autenticado no se encontro.{idEmployee}");
        var taskFound = await _repository.ObtenerPorId<Domain.Entities.Task>(idTask, nameof(Domain.Entities.Task.Function));
        if (taskFound == null) throw new EntityNotFoundException($"La tarea de id {idTask} no se encontró.");
        if (taskFound.State == StateProgress.Completed && taskFound.ImplementationStatus == StateTask.Completed) throw new BusinessConflictException("La tarea ya esta completada.");
        if (employeeFound.RolEmpleado == EmployeeRol.Developer && taskFound.ImplementationStatus == StateTask.Development)
        {
            taskFound.ImplementationStatus = StateTask.Testing;
        }
        else if (employeeFound.RolEmpleado == EmployeeRol.Tester && taskFound.ImplementationStatus == StateTask.Testing)
        {
            taskFound.ImplementationStatus = StateTask.Completed;
        }
        else
        {
            throw new BusinessConflictException("No se puede modificar el estado de la tarea.");
        }
        if (taskFound.ImplementationStatus == StateTask.Completed)
        {
            taskFound.State = StateProgress.Completed;
        }
        await _repository.Actualizar(taskFound);
        await ValidateStateProject(taskFound.Function!.ProyectId);
        return true;
    }
    public async Task<bool> DeleteTask(int idTask)
    {
        var taskFound = await _repository.ObtenerPorId<Domain.Entities.Task>(idTask);
        if (taskFound == null) throw new EntityNotFoundException($"La tarea de id {idTask} no se encontró.");
        taskFound.State = StateProgress.Cancelled;
        await _repository.Actualizar(taskFound);
        return true;
    }
    private async System.Threading.Tasks.Task ValidateStateProject(int idProject)
    {
        var project = await _repository.ObtenerPorId<Proyect>(idProject, nameof(Proyect.Functions), "Functions.Tasks");
        if (project == null) throw new EntityNotFoundException("El proyecto no se encontró.");
        project.Functions = await _repository.Listar<Function>(f => f.ProyectId == project.Id, nameof(Function.Tasks));
        var allFunctionsCompleted = project.Functions != null && project.Functions.All(f => f.IsCompleted());
        project.State = allFunctionsCompleted ? StateProgress.Completed : project.State;
        await _repository.Actualizar(project);
    }
}