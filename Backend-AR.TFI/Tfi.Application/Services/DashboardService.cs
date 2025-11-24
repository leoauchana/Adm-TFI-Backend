using MapsterMapper;
using Tfi.Application.DTOs;
using Tfi.Application.Exceptions;
using Tfi.Application.Interfaces;
using Tfi.Domain.Entities;
using Tfi.Domain.Enum;
using Tfi.Domain.Repository;

namespace Tfi.Application.Services;

public class DashboardService : IDashboardService
{
    private readonly IRepository _repository;
    private readonly IMapper _mapper;

    public DashboardService(IRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<DashboardDto.ResponseProgressPercentage>?> GetProjectsProgress()
    {
        var projectsRegistered = await GetProjectsWithFuctionsAndTasks();
        var result = new List<DashboardDto.ResponseProgressPercentage>();
        foreach (var project in projectsRegistered.Where(p => p.State == StateProgress.Progress))
        {
            var progress = CalculateProjectProgress(project);
            var progressDto = new DashboardDto.ResponseProgressPercentage
            (
                _mapper.Map<Proyect, ProjectDto.ResponseMinimal>(project),
                Math.Round(progress, 2)
            );
            result.Add(progressDto);
        }
        return result;
    }
    public async Task<List<DashboardDto.ResponseTeamWithPerformance>?> GetLoadPerTeam()
    {
        var teamRegistered = await _repository.ListarTodos<Team>(nameof(Team.Employees), nameof(Team.Proyects));
        if (teamRegistered == null) throw new NullException("No hay equipos registrados.");
        return teamRegistered.Select(t => new DashboardDto.ResponseTeamWithPerformance(
            t.Number,
            t.Proyects != null ? t.Proyects.Where(p => p.State != StateProgress.Cancelled).ToList()!.Count : 0,
            t.Proyects != null ? t.Proyects.Where(p => p.State == StateProgress.Completed).ToList().Count : 0,
            t.Proyects != null ? t.Proyects.Where(p => p.State == StateProgress.Progress).ToList().Count : 0
            )).ToList();
    }
    private async Task<List<Proyect>> GetProjectsWithFuctionsAndTasks()
    {
        var proyectsRegistered = await _repository.ListarTodos<Proyect>(nameof(Client), nameof(Team), "Team.Employees");
        if (proyectsRegistered == null || !proyectsRegistered.Any()) throw new NullException("No hay proyectos registrados.");
        foreach (var project in proyectsRegistered)
        {
            project.Functions = await _repository.Listar<Function>(f => f.ProyectId == project.Id, nameof(Function.Tasks));
        }
        return proyectsRegistered;
    }
    private double CalculateProjectProgress(Proyect project)
    {
        var allTasks = project.Functions?
            .SelectMany(f => f.Tasks)
            .ToList();

        if (!allTasks.Any())
            return 0;

        var completed = allTasks.Count(t => t.State == StateProgress.Completed);

        return (completed / (double)allTasks.Count) * 100;
    }
}
