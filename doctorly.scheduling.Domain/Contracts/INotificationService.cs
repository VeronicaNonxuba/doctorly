using doctorly.scheduling.Domain.Aggregates;

namespace doctorly.scheduling.Domain.Contracts;

public interface INotificationService
{
    Task NotifyEventCreated(Event @event);
    Task NotifyEventUpdated(Event @event);
    Task NotifyEventCancelled(int eventId);
    // ... Other notifications for Attendees
}
