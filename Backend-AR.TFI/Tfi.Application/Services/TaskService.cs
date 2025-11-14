using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
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
        await _repository.Agregar(newTask);
        return _mapper.Map<Domain.Entities.Task, TaskDto.Response>(newTask);
    }
}
