using Mapster;
using Tfi.Application.DTOs;
using Tfi.Domain.Entities;
using Tfi.Domain.Enum;

namespace Tfi.Application.Map;

public static class MappingConfig
{
    public static void RegisterConfig()
    {
        TypeAdapterConfig<ProyectDto.Request, Proyecto>
            .NewConfig()
            .Map(dest => dest.NombreProyecto, src => src.nameProyect)
            .Map(dest => dest.DescripcionProyecto, src => src.descriptionProyect)
            .Map(dest => dest.PresupuestoProyecto, src => src.budgetProyect)
            .Map(dest => dest.FechaFinProyecto, src => src.dateEnd)
            .Map(dest => dest.TipoProyecto, src => src.typeProyect)
            .Map(dest => dest.PrioridadProyecto, src => src.priorityProyect)
            .Map(dest => dest.EstadoProyecto, src => EstadoAvance.En_Curso)
            .Map(dest => dest.IdCliente, src => src.idClient)
            .Map(dest => dest.IdEquipo, src => src.idTeam)
            .Map(dest => dest.FechaInicioPreyecto, src => DateOnly.FromDateTime(DateTime.UtcNow));

        TypeAdapterConfig<Proyecto, ProyectDto.Response>
            .NewConfig().Map(dest => dest.nameProyect, src => src.NombreProyecto)
            .Map(dest => dest.descriptionProyect, src => src.DescripcionProyecto)
            .Map(dest => dest.budgetProyect, src => src.PresupuestoProyecto)
            .Map(dest => dest.dateEnd, src => src.FechaFinProyecto)
            .Map(dest => dest.typeProyect, src => src.TipoProyecto)
            .Map(dest => dest.priorityProyect, src => src.PrioridadProyecto.ToString())
            .Map(dest => dest.stateProyect, src => src.EstadoProyecto.ToString())
            .Map(dest => dest.client, src => src.Cliente)
            .Map(dest => dest.numberTeam, src => src.Equipo.NumeroEquipo)
            .Map(dest => dest.dataInitial, src => src.FechaInicioPreyecto);

        TypeAdapterConfig<Cliente, ClientDto.Response>
            .NewConfig()
            .Map(dest => dest.fullNameClient, src => src.NombreCliente)
            .Map(dest => dest.mailClient, src => src.MailCliente)
            .Map(dest => dest.dniClient, src => src.Dni)
            .Map(dest => dest.directionClient, src => src.DireccionCliente)
            .Map(dest => dest.phoneClient, src => src.TelefonoCliente);

    }
}
