using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Enum;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class ProjectsService : IProyectsService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;
    public ProjectsService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ProjectDto.Response?> AddProyect(ProjectDto.Request newProyectRequest)
    {
        var clientRegistered = await _repository
                                        .ObtenerPorId<Client>
                                         (newProyectRequest.idClient);
        if (clientRegistered == null) throw new EntityNotFoundException("El cliente seleccionado no se encuentra registrado.");
        var teamRegistered = await _repository
                                    .ObtenerPorId<Team>
                                     (newProyectRequest.idTeam);
        if (teamRegistered == null) throw new EntityNotFoundException("El equipo seleccionado no se encuentra registrado.");
        var proyectFound = await _repository
                                    .ObtenerElPrimero<Proyect>
                                     (p => p.Name == newProyectRequest.nameProject);
        if (proyectFound != null) throw new BusinessConflictException("Ya existe un proyecto registrado con el nombre ingresado.");
        var newProyect = _mapper.Map<ProjectDto.Request, Proyect>(newProyectRequest);
        await _repository.Agregar(newProyect);
        return _mapper.Map<Proyect, ProjectDto.Response>(newProyect);
    }
    public async Task<bool> DeleteProyect(int idProyect)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyect>(idProyect);
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontro el proyecto con {idProyect}");
        if (proyectFound.State == StateProgress.Cancelled) throw new BusinessConflictException($"El proyecto con id {idProyect} ya fue dado de baja.");
        proyectFound.State = StateProgress.Cancelled;
        await _repository.Actualizar(proyectFound);
        return true;
    }
    public async Task<List<ProjectDto.Response>?> GetAll()
    {
        var proyectsRegistered = await _repository
                                        .ListarTodos<Proyect>(nameof(Proyect.Functions), nameof(Client), nameof(Team), nameof(Proyect.Incidences));
        if (proyectsRegistered == null || !proyectsRegistered.Any()) throw new NullException("No hay proyectos registrados.");
        var proyectsList = proyectsRegistered
                                    .Where(p => p.State != StateProgress.Cancelled && p.State != StateProgress.Completed)
                                    .Select(p => _mapper.Map<Proyect, ProjectDto.Response>(p))
                                    .ToList();
        return proyectsList;
    }
    public async Task<ProjectDto.ResponseById?> GetById(int idProyect)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyect>(idProyect, nameof(Proyect.Incidences), nameof(Client), nameof(Team), "Team.Employees");
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontro el proyecto con id {idProyect}");
        if (proyectFound.State == StateProgress.Cancelled) throw new BusinessConflictException($"El proyecto con id {idProyect} fue dado de baja.");
        var proyectFunctions = await _repository.Listar<Function>(f => f.ProyectId == proyectFound.Id, nameof(Function.Tasks));
        proyectFound.Functions = proyectFunctions;
        return _mapper.Map<Proyect, ProjectDto.ResponseById>(proyectFound);
    }
    public async Task<ProjectDto.Response?> UpdateProyect(ProjectDto.RequestUpdate proyectData)
    {
        if ((proyectData.newFunctions.Count <= 0)) throw new BusinessConflictException("Se deben agregar las funcionalidades correspondientes.");
        var proyectFound = await _repository.ObtenerPorId<Proyect>(proyectData.idProject, nameof(Proyect.Functions));
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontró el proyecto con id {proyectData.idProject}");
        var newChangeHistory = new ChangeHistory
        {
            ProyectId = proyectFound.Id,
            EmployeeId = 8,
            Functions = proyectFound.Functions,
            Budget = proyectFound.Budget,
            ChangeDate = DateTime.UtcNow,
            Reason = proyectData.changeReason
        };
        proyectFound.Description = proyectData.newDescriptionProject;
        proyectFound.Budget = proyectData.newBudgetProject;
        proyectFound.DateEnd = proyectData.dateEnd;
        foreach(var newFunction in proyectData.newFunctions)
        {
            proyectFound.Functions!.Add(_mapper.Map<FunctionsDto.Request, Function>(newFunction));
        }
        await _repository.Agregar(newChangeHistory);
        await _repository.Actualizar(proyectFound);
        return _mapper.Map<Proyect, ProjectDto.Response>(proyectFound);
    }
    public async Task<ProjectDto.ResponseHistory?> GetHistoryById(int idProject)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyect>(idProject, nameof(Proyect.ChangesHistory), "ChangesHistory.Functions");
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontro el proyecto con id {idProject}");
        return _mapper.Map<Proyect, ProjectDto.ResponseHistory>(proyectFound);
    }
}
