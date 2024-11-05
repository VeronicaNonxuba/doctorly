namespace doctorly.scheduling.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string Fullname { get; set; }
    public required string Email { get; set; }
    public string? ContactNo { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}
