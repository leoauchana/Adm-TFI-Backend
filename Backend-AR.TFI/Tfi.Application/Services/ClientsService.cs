using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class ClientsService : IClientsService
{
    private readonly IRepository _repository;
	private readonly IMapper _mapper;

	public ClientsService(IRepository repository, IMapper mapper) 
	{
		_repository = repository;
		_mapper = mapper;
	}
	public async Task<List<ClientDto.Response>?> GetAll()
	{
		var clientsRegistered = await _repository.ListarTodos<Client>();
		if (clientsRegistered == null) throw new NullException("No hay clientes registrados.");
		return clientsRegistered
				.Select(c => _mapper.Map<Client, ClientDto.Response>(c))
				.ToList();
	}
}
