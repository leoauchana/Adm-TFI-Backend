using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IResourcesService
{
    Task<List<ResourceDto.Response>> GetAll();
}
