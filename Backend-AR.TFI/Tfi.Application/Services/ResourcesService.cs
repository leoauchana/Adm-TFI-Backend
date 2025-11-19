using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class ResourcesService : IResourcesService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;
    public ResourcesService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ResourceDto.Response>> GetAll()
    {
        var resourceList = await _repository.ListarTodos<Resource>();
        if (resourceList == null) throw new EntityNotFoundException("No hay recursos registrados");
        return resourceList.Select(r => _mapper.Map<Resource, ResourceDto.Response>(r))
            .ToList();
    }
}
