using Tfi.Application.DTOs;
using Tfi.Application.Interfaces;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class IncidencesService : IIncidencesService
{
    private readonly IRepository _repository;

	public IncidencesService(IRepository repository)
	{
		_repository = repository;
	}
	public async Task<IncidenceDto.Response> GetIncidences(int idProyect)
	{
		return null;
	}
	public async Task<IncidenceDto.Response> RegisterIncidence(IncidenceDto.Request incidenceData)
	{
		
		return null;
	}

}
