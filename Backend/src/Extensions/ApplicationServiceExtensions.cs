using Backend.Data;
using Backend.Interfaces;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

namespace Backend.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services,
        IConfiguration config
    )
    {
        services.AddDbContext<DataContext>(opt =>
        {
            var connectionString =
                Environment.GetEnvironmentVariable("ConnectionStrings:DefaultConnection")
                ?? config["ConnectionStrings:DefaultConnection"];
            opt.UseNpgsql(connectionString);
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IShoesRepository, ShoesRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}
