using Backend.Infrastructure.Interceptors;
using Backend.Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICleanArchitectureContext>(serviceProvider => serviceProvider.GetRequiredService<CleanArchContext>());
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<CleanArchContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Backend.Infrastructure"));
        });
        
        

        return services;
    }
    
}