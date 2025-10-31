namespace Tfi.Application.DTOs;

public class IncidenceDto
{
    public record Request(int idProyect, string typeIncidence, string descriptionIncidence);
    public record Response(string typeIncidence, string descriptionIncidence);
}
