using Tfi.Domain.Entities;

namespace Tfi.Application.DTOs;

public class HistoryDto
{
    public record Response(string changeReason, double oldBudget, List<ResponseOldFunction> oldFunctions, DateOnly changeDate);
    public record ResponseOldFunction(string name, string description);
}
