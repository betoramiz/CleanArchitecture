using Backend.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Backend.Infrastructure.Interceptors;

public class DispatchDomainEventsInterceptor: SaveChangesInterceptor
{
    private readonly IPublisher _publisher;
    public DispatchDomainEventsInterceptor(IPublisher publisher) => _publisher = publisher;

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is not null)
            await DispatchDomainEvents(eventData.Context);
        
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private async Task DispatchDomainEvents(DbContext context)
    {
        var domainEvents = context.ChangeTracker
            .Entries<Entity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .SelectMany(e =>
            {
                var events = new List<IDomainEvent>();
                events.AddRange(e.Entity.DomainEvents);
                e.Entity.DomainEvents.Clear();
                return events;
            })
            .ToList();
            
        foreach (var domainEvent in domainEvents) 
            await _publisher.Publish(domainEvent);
    }
}