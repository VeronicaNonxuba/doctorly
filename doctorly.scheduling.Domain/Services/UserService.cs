namespace doctorly.scheduling.Domain.Services;

public class UserService : IUserService
{
    public readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUserAsync(Credential credential)
    {
        return await _userRepository.GetUserAsync(credential);
    }

    public async Task<Credential> GetUserCredentialsAsync(int id)
    {
        return await _userRepository.GetUserCredentialsAsync(id);
    }
}
