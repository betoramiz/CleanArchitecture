using Clean.Application.Data;
using Clean.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Clean.Infrastructure;

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
            options.UseSqlServer(connectionString, x => x.MigrationsAssembly("Clean.Infrastructure"));
        });
        
        

        return services;
    }
    
}