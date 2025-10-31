using Microsoft.Extensions.DependencyInjection;
using Tfi.Application.Interfaces;
using Tfi.Application.Services;

namespace Tfi.Application;

public static class ServicesExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProyectsService, ProyectsService>();
        services.AddScoped<IIncidencesService, IncidencesService>();
        services.AddScoped<IClientsService, ClientsService>();
        services.AddScoped<ITeamsService, TeamsService>();
    }
}
