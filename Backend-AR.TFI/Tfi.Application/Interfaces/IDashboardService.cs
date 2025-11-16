using Tfi.Application.DTOs;

namespace Tfi.Application.Interfaces;

public interface IDashboardService
{
    Task<List<DashboardDto.ResponseProgressPercentage>?> GetProjectsProgress();
    Task<List<DashboardDto.ResponseTeamWithPerformance>?>  GetLoadPerTeam();
}
