using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface ITeamsService
{
    Task<List<TeamDto.ResponseById>?> GetAll();
}
