namespace doctorly.scheduling.Domain.Entities;

public class Attendee
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string EmailAddress { get; set; }
    public bool Attending { get; set; }
}
