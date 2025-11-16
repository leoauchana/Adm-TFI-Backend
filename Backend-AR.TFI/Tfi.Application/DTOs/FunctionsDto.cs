namespace Tfi.Application.DTOs;

public class FunctionsDto
{
    public record Request(string functionName, string functionDescription);
    public record Response(string functionName, string functionDescription);
    public record ResponseById(string functionName, string functionDescription, List<TaskDto.Response>? tasks);
}
