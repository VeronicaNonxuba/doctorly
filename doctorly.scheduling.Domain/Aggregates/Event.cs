using doctorly.scheduling.Domain.Common;
using doctorly.scheduling.Domain.Events.Attendee;

namespace doctorly.scheduling.Domain.Aggregates;

public class Event : AggregateRoot
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public List<Attendee> Attendees { get; set; } = new List<Attendee>();

    public void AddAttendee(Attendee attendee)
    {
        Attendees.Add(attendee);
        AddDomainEvent(new AttendeeAdded(attendee.Id, this.Id)); // Domain Event
    }

    // Other methods: Update, Cancel, etc. 
}
