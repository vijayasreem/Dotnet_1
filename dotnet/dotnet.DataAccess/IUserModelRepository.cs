
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;

namespace dotnet.Service
{
    public interface IUserModelRepository
    {
        Task<int> CreateUser(UserModel user);
        Task<UserModel> GetUserById(int id);
        Task<List<UserModel>> GetAllUsers();
        Task<int> UpdateUser(UserModel user);
        Task<int> DeleteUser(int id);
    }
}
