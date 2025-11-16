using Tfi.Domain.Entities;

namespace Tfi.Application.DTOs;

public class HistoryDto
{
    public record Response(string changeReason, double oldBudget, List<FunctionsDto.Response> oldFunctions, DateOnly changeDate);
}
