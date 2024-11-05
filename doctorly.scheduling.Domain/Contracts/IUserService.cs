namespace doctorly.scheduling.Domain.Contracts;

public interface IUserService
{
    Task<User> GetByIdAsync(int id);
    Task<Credential> GetUserCredentialsAsync(int id);
    Task<User> GetUserAsync(Credential credential);
}
