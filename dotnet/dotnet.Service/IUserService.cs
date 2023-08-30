public interface IUserService
{
    Task<int> CreateUser(UserDto user);
    Task<UserDto> GetUserById(int id);
    Task<List<UserDto>> GetAllUsers();
    Task<int> UpdateUser(UserDto user);
    Task<int> DeleteUser(int id);
}