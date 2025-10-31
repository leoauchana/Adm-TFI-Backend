using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IIncidencesService
{
    Task<List<IncidenceDto.Response>?> GetIncidences(int idProyect);
    Task<IncidenceDto.Response> RegisterIncidence(IncidenceDto.Request newIncidence);

}
