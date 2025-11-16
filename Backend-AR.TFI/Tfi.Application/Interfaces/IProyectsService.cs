using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IProyectsService
{
    Task<ProjectDto.Response?> AddProyect(ProjectDto.Request newProyect);
    Task<List<ProjectDto.Response>?> GetAll();
    Task<ProjectDto.ResponseById?> GetById(int idProyect);
    Task<bool> DeleteProyect(int idProyect);
    Task<ProjectDto.Response?> UpdateProyect(ProjectDto.RequestUpdate proyectData);
    Task<ProjectDto.ResponseHistory?> GetHistoryById(int idProyect);
}
