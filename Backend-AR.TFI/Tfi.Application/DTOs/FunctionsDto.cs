namespace Tfi.Application.DTOs;

public class FunctionsDto
{
    public record Request(string functionName, string functionDescription);
    public record Response(int idFunction, string functionName, string functionDescription);
    public record ResponseById(int idFunction, string functionName, string functionDescription, List<TaskDto.Response>? tasks);
}
