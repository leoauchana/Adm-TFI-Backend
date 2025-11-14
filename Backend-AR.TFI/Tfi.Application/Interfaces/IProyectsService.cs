using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IProyectsService
{
    Task<ProjectDto.Response?> AddProyect(ProjectDto.Request newProyect);
    Task<List<ProjectDto.Response>?> GetAll();
    Task<ProjectDto.Response?> GetById(int idProyect);
    Task<ProjectDto.Response?> DeleteProyect(int idProyect);
    Task<ProjectDto.Response?> UpdateProyect(ProjectDto.RequestUpdate proyectData);
}
