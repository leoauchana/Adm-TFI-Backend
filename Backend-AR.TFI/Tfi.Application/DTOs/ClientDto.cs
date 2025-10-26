namespace Tfi.Application.DTOs;

public class ClientDto
{
    public record Response(string fullNameClient, int dniClient, string directionClient, string mailClient, string phoneClient);
}
