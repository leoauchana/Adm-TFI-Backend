using Mapster;
using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Enum;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class ProyectsService : IProyectsService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;
    public ProyectsService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ProyectDto.Response?> AddProyect(ProyectDto.Request newProyectRequest)
    {
        var clientRegistered = await _repository
                                        .ObtenerPorId<Cliente>
                                         (newProyectRequest.idClient);
        if (clientRegistered == null) throw new EntityNotFoundException("El cliente seleccionado no se encuentra registrado.");
        var teamRegistered = await _repository
                                    .ObtenerPorId<Equipo>
                                     (newProyectRequest.idTeam);
        if (teamRegistered == null) throw new EntityNotFoundException("El equipo seleccionado no se encuentra registrado.");
        var proyectFound = await _repository
                                    .ObtenerElPrimero<Proyecto>
                                     (p => p.NombreProyecto == newProyectRequest.nameProyect);
        if (proyectFound != null) throw new BusinessConflictException("Ya existe un proyecto registrado con el nombre ingresado.");
        var newProyect = _mapper.Map<ProyectDto.Request, Proyecto>(newProyectRequest);
        await _repository.Agregar(newProyect);
        return _mapper.Map<Proyecto, ProyectDto.Response>(newProyect);
    }

    public async Task<ProyectDto.Response?> DeleteProyect(int idProyect)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyecto>(idProyect);
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontro el proyecto con {idProyect}");
        proyectFound.EstadoProyecto = EstadoAvance.Cancelado;
        await _repository.Actualizar(proyectFound);
        return _mapper.Map<Proyecto, ProyectDto.Response>(proyectFound);
    }

    public async Task<List<ProyectDto.Response>?> GetAll()
    {
        var proyectsRegistered = await _repository
                                        .ListarTodos<Proyecto>(nameof(Proyecto.Funcionalidades), nameof(Cliente), nameof(Equipo));
        if (proyectsRegistered == null) throw new NullException("No hay proyectos registrados.");
        var proyectsList = proyectsRegistered
                                    .Where(p => p.EstadoProyecto != EstadoAvance.Cancelado)
                                    .Select(p => _mapper.Map<Proyecto, ProyectDto.Response>(p))
                                    .ToList();
        return proyectsList;
    }
    public async Task<ProyectDto.Response?> GetById(int idProyect)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyecto>(idProyect);
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontro el proyecto con id {idProyect}");
        return _mapper.Map<Proyecto, ProyectDto.Response>(proyectFound);
    }

    public async Task<ProyectDto.Response?> UpdateProyect(ProyectDto.RequestUpdate proyectData)
    {
        var proyectFound = await _repository.ObtenerPorId<Proyecto>(proyectData.idProyect);
        if (proyectFound == null) throw new EntityNotFoundException($"No se encontró el proyecto con id {proyectData.idProyect}");
        proyectFound.DescripcionProyecto = proyectData.newDescriptionProyect;
        proyectFound.PresupuestoProyecto = proyectData.newBudgetProyect;
        await _repository.Actualizar(proyectFound);
        return _mapper.Map<Proyecto, ProyectDto.Response>(proyectFound);
    }
}
