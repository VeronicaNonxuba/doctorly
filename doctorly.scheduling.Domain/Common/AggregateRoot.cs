using doctorly.scheduling.Domain.Contracts;

namespace doctorly.scheduling.Domain.Common;

public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    // Optionally: Clear Domain Events after handling 
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}