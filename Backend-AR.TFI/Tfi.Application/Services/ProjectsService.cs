using MapsterMapper;
using Microsoft.Extensions.Logging;
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

    public async Task<ProjectDto.Response?> DeleteProyect(int idProyect)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyect>(idProyect);
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontro el proyecto con {idProyect}");
        proyectFound.State = StateProgress.Cancelled;
        await _repository.Actualizar(proyectFound);
        return _mapper.Map<Proyect, ProjectDto.Response>(proyectFound);
    }

    public async Task<List<ProjectDto.Response>?> GetAll()
    {
        var proyectsRegistered = await _repository
                                        .ListarTodos<Proyect>(nameof(Proyect.Functions), nameof(Client), nameof(Team), nameof(Proyect.Incidences),"Team.Employees");
        if (proyectsRegistered == null || !proyectsRegistered.Any()) throw new NullException("No hay proyectos registrados.");
        var proyectsList = proyectsRegistered
                                    .Where(p => p.State != StateProgress.Cancelled)
                                    .Select(p => _mapper.Map<Proyect, ProjectDto.Response>(p))
                                    .ToList();
        return proyectsList;
    }
    public async Task<ProjectDto.Response?> GetById(int idProyect)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyect>(idProyect, nameof(Proyect.Functions), nameof(Client), nameof(Team), "Team.Employees");
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontro el proyecto con id {idProyect}");
        //var employeesTeam = await _repository.Listar<Employee>(e => e.TeamId == proyectFound.Team!.Id);
        //proyectFound.Team!.Employees = employeesTeam;
        return _mapper.Map<Proyect, ProjectDto.Response>(proyectFound);
    }

    public async Task<ProjectDto.Response?> UpdateProyect(ProjectDto.RequestUpdate proyectData)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyect>(proyectData.idProject);
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontró el proyecto con id {proyectData.idProject}");
        proyectFound.Description = proyectData.newDescriptionProject;
        proyectFound.Budget = proyectData.newBudgetProject;
        await _repository.Actualizar(proyectFound);
        return _mapper.Map<Proyect, ProjectDto.Response>(proyectFound);
    }
}
