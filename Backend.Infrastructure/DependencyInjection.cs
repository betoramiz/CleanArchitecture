using System.Reflection;
using Backend.Application.Common.Interfaces;
using Backend.Infrastructure.Interceptors;
using Backend.Application.Data;
using Backend.Infrastructure.Common;
using Backend.Infrastructure.Persistence;
using Backend.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) =>
        services
            .AddPersistence(configuration)
            .AddRepositories()
            .AddServices()
            .AddOptionPattern(configuration);

    private static IServiceCollection AddOptionPattern(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.Option));
        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICleanArchitectureContext>(serviceProvider => serviceProvider.GetRequiredService<CleanArchContext>());
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        
        return services;
    }
    
    private static IServiceCollection AddRepositories(this IServiceCollection services) => 
        services
            .Scan(selector => selector
                .FromAssemblyOf<IRepository>()
                .AddClasses(classSelector => classSelector
                    .InNamespaces()
                    .AssignableTo<Repository>()
                )
            );

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var thisAssembly = Assembly.GetExecutingAssembly().GetName().Name;
        var connectionString = configuration.GetConnectionString("ConnectionString");
        services.AddDbContext<CleanArchContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString, x => x.MigrationsAssembly(thisAssembly));
        });

        return services;
    }
    
}