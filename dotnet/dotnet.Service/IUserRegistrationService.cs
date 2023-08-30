public interface IUserRegistrationService
{
    Task<int> CreateUserAsync(UserRegistrationDTO user);
    Task<UserRegistrationDTO> GetUserByIdAsync(int id);
    Task<IEnumerable<UserRegistrationDTO>> GetAllUsersAsync();
    Task<bool> UpdateUserAsync(UserRegistrationDTO user);
    Task<bool> DeleteUserAsync(int id);
}