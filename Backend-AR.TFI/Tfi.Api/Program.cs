using FluentValidation.AspNetCore;
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
                    policy.RequireRole("Manager");
                });
                options.AddPolicy("TeamMember", policy =>
                {
                    policy.RequireRole("Developer", "Tester");
                });
                options.AddPolicy("TasksActions", policy =>
                {
                    policy.RequireRole("Developer", "Tester", "Manager");
                });
                options.AddPolicy("GetProyects", policy =>
                {
                    policy.RequireRole("Administrator", "Manager", "Developer", "Tester");
                });
            });
            builder.Services.AddMapster();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddDataServices(builder.Configuration);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()     
                        .WithOrigins(   
                            "http://localhost:5173"
                        );
                });
            });
            builder.Services.AddFluentValidationAutoValidation();

            var app = builder.Build();

            app.UseCors("AllowFrontend");

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
