namespace doctorly.scheduling.Domain.Events.Attendee;

public class AttendeeAdded : IDomainEvent
{
    private int AttendeeId { get; set; }
    public int EventId { get; set; }

    public AttendeeAdded(int attendeeId, int eventId)
    {
        AttendeeId = attendeeId;
        EventId = eventId;
    }
}
