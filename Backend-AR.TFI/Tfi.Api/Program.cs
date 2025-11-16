using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Tfi.Api.Middleware;
using Tfi.Application;
using Tfi.Application.Map;
using Tfi.Data;

namespace Tfi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", policy =>
                {
                    policy.RequireRole("Administrator");
                });
                options.AddPolicy("ProjectManager", policy =>
                {
                    policy.RequireRole("ProjectManager");
                });
                options.AddPolicy("TeamMember", policy =>
                {
                    policy.RequireRole("Developer", "Tester");
                });
            });
            builder.Services.AddMapster();

            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddApplicationServices(builder.Configuration);

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
