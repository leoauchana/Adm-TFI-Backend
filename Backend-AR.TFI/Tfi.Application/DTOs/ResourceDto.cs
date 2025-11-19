namespace Tfi.Application.DTOs;

public class ResourceDto
{
    public record Request(int idResource);
    public record Response(int idResource, string resourceDescription);
}
