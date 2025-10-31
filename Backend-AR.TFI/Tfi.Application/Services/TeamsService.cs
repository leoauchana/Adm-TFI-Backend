using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class TeamsService : ITeamsService
{
    private readonly IRepository _repository;
	private readonly IMapper _mapper;
	public TeamsService(IRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
	public async Task<List<TeamDto.Response>?> GetAll()
	{
		var teamsRegistered = await _repository
							.ListarTodos<Equipo>(nameof(Equipo.Empleados));
		if (teamsRegistered == null) throw new NullException("No hay equipos registrados.");
		return teamsRegistered
				.Select(t => _mapper.Map<Equipo, TeamDto.Response>(t))
				.ToList();
	}
}
