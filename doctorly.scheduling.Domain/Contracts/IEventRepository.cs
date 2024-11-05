using doctorly.scheduling.Domain.Aggregates;

namespace doctorly.scheduling.Domain.Contracts;

public interface IEventRepository
{
    Task Add(Event @event);
    Task<Event> GetByIdAsync(int eventId);
    Task Update(Event @event);
    Task Remove(Event @event);
    Task SaveChangesAsync();
}
