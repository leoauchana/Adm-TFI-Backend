using Tfi.Application;
using Tfi.Data;
using Mapster;
using Tfi.Application.Map;
using Tfi.Api.Middleware;

namespace Tfi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddMapster();

            builder.Services.AddEndpointsApiExplorer();

            //builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationServices();

            builder.Services.AddDataServices(builder.Configuration);

            var app = builder.Build();

            MappingConfig.RegisterConfig();
            
            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
