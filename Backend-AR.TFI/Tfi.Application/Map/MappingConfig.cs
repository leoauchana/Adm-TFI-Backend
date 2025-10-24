using Mapster;
using Tfi.Application.DTOs;
using Tfi.Domain.Entities;

namespace Tfi.Application.Map;

public static class MappingConfig
{
    public static void RegisterConfig()
    {
        TypeAdapterConfig<ProyectDto.Request, Proyecto>
            .NewConfig()
            .Map(dest => dest.IdCliente, src => src.idClient)
            .Map(dest => dest.IdEquipo, src => src.idTeam);

        TypeAdapterConfig<Proyecto, ProyectDto.Response>
            .NewConfig();
    }
}
