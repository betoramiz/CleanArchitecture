using Clean.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("");
        services.AddDbContext<CleanArchContext>(options =>
        {
            options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Clean.Infrastructure"));
        });
        
        services.AddScoped<ICleanArchitectureContext>(serviceProvider => serviceProvider.GetRequiredService<CleanArchContext>());

        return services;
    }
    
}