using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tfi.Data.Context;
using Tfi.Domain.Repository;

namespace Tfi.Data;

public static class ServicesExtensions
{
    public static void AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRepository, Repository.Repository>();
        services.AddDbContext<TfiContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DbMySql");

            options.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString));
        });
    }
}
