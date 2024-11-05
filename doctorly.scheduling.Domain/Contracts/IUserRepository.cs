namespace doctorly.scheduling.Domain.Contracts;

public interface IUserRepository
{
    Task<User> GetByIdAsync(int id);
    Task<Credential> GetUserCredentialsAsync(int id);
    Task<User> GetUserAsync(Credential credential);
}
