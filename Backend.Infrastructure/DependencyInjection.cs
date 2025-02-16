using System.Reflection;
using Backend.Infrastructure.Interceptors;
using Backend.Application.Data;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringOptions>(configuration.GetSection("ConnectionString"));
        
        services.AddPersistence(configuration);
        
        services.AddScoped<ICleanArchitectureContext>(serviceProvider => serviceProvider.GetRequiredService<CleanArchContext>());
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var thisAssembly = Assembly.GetExecutingAssembly().GetName().Name;
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<CleanArchContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString, x => x.MigrationsAssembly(thisAssembly));
        });

        return services;
    }
    
}