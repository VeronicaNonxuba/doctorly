using doctorly.scheduling.Domain.Aggregates;

namespace doctorly.scheduling.Domain.Services;

public class EmailNotificationService : INotificationService
{
    public EmailNotificationService()
    {
    }
    public Task NotifyEventCancelled(int eventId)
    {
        throw new NotImplementedException();
    }

    public Task NotifyEventCreated(Event @event)
    {
        throw new NotImplementedException();
    }

    public Task NotifyEventUpdated(Event @event)
    {
        throw new NotImplementedException();
    }
}
