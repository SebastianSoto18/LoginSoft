using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using SoftTechChallenge.Common;
using SoftTechChallenge.Infraestructure.Managers;
using SoftTechChallenge.Infraestructure.Managers.Interfaces;
using SoftTechChallenge.Infraestructure.Models;
using SoftTechChallenge.Infraestructure.Repositories;
using SoftTechChallenge.Infraestructure.Repositories.Interfaces;


namespace SoftTechChallenge.Infraestructure;

public static class Extension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<TokenProvider>();

        services.AddScoped<IAuthManager, AuthManager>();
        
        services.AddTransient<IRepository<User>,Repository<User>>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"));
        });

    }
    public static void AddCustomCors(this IServiceCollection services)
    {
        //CORS
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.WithOrigins(new[]
                    {
                        "http://localhost:4200",
                        "http://localhost:5000"
                    })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });

        services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
    
    
}