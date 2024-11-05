using doctorly.scheduling.Domain.Aggregates;

namespace doctorly.scheduling.Domain.Contracts;

public interface IEventService
{
    Task<Event> CreateEventAsync(string title, string description, DateTime startTime, DateTime endTime);
    Task<Event> GetEventAsync(int eventId);
    Task UpdateEventAsync(Event updatedEvent);
    Task CancelEventAsync(int eventId);
    Task AddAttendeeAsync(int eventId, Attendee attendee);
    Task<List<Event>> GetEventsAsync(DateTime? start, DateTime? end);
    Task<List<Event>> SearchEventsAsync(string query);
}
