namespace Tfi.Application.DTOs;

public class ClientDto
{
    public record Response(int idClient, string fullNameClient, int dniClient, string directionClient, string mailClient, string phoneClient);
    public record ResponseWithProjects(string fullNameClient, int dniClient, string directionClient, string mailClient, string phoneClient,
        List<ProjectDto.Response> projects);
}
