namespace Clean.Domain.Common;

public abstract class Entity
{
    private readonly List<IDomainEvent> _events = new ();

    protected Entity()
    {
    }

    protected void RaiseEvent(IDomainEvent domainEvent) => _events.Add(domainEvent);

    public ICollection<IDomainEvent> DomainEvents => _events;
    
}