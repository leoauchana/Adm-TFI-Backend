using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class IncidencesService : IIncidencesService
{
    private readonly IRepository _repository;
	private readonly IMapper _mapper;
	public IncidencesService(IRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}
	public async Task<List<IncidenceDto.Response>?> GetIncidences(int idProyect)
	{
		var incidencesRegistered = await _repository.Listar<Incidencium>(i => i.IdProyecto == idProyect);
		if (incidencesRegistered == null || !(incidencesRegistered.Count > 0)) 
			throw new NullException("No hay incidencias del proyecto");
		var incidenceList =  incidencesRegistered
					.Select(i => _mapper.Map<Incidencium, IncidenceDto.Response>(i))
					.ToList();
		return incidenceList;
	}
	public async Task<IncidenceDto.Response> RegisterIncidence(IncidenceDto.Request incidenceData)
	{
		var proyectFound = await _repository.ObtenerPorId<Proyecto>(incidenceData.idProyect);
		if (proyectFound == null) throw new EntityNotFoundException($"No se encontró el proyecto de id {incidenceData.idProyect}");
		var newIncidence = _mapper.Map<IncidenceDto.Request, Incidencium>(incidenceData);
		await _repository.Agregar(newIncidence);
		return _mapper.Map<Incidencium, IncidenceDto.Response>(newIncidence);
	}

}
