using doctorly.scheduling.Domain.Aggregates;

namespace doctorly.scheduling.Domain.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly INotificationService _notificationService; // For sending notifications

    public EventService(IEventRepository eventRepository, INotificationService notificationService)
    {
        _eventRepository = eventRepository;
        _notificationService = notificationService;
    }

    public Task AddAttendeeAsync(int eventId, Attendee attendee)
    {
        throw new NotImplementedException();
    }

    public Task CancelEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public async Task<Event> CreateEventAsync(string title, string description, DateTime startTime, DateTime endTime)
    {
        var newEvent = new Event
        {
            Title = title,
            Description = description,
            StartTime = startTime,
            EndTime = endTime
        };

        await _eventRepository.Add(newEvent);
        await _eventRepository.SaveChangesAsync();
        await _notificationService.NotifyEventCreated(newEvent); // Send a notification

        return newEvent;
    }

    public Task<Event> GetEventAsync(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Event>> GetEventsAsync(DateTime? start, DateTime? end)
    {
        throw new NotImplementedException();
    }

    public Task<List<Event>> SearchEventsAsync(string query)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEventAsync(Event updatedEvent)
    {
        throw new NotImplementedException();
    }

    // ... Implement other methods of IEventService interface
}