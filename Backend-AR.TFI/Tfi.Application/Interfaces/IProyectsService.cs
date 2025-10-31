using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IProyectsService
{
    Task<ProyectDto.Response?> AddProyect(ProyectDto.Request newProyect);
    Task<List<ProyectDto.Response>?> GetAll();
    Task<ProyectDto.Response?> GetById(int idProyect);
    Task<ProyectDto.Response?> DeleteProyect(int idProyect);
    Task<ProyectDto.Response?> UpdateProyect(ProyectDto.RequestUpdate proyectData);
}
