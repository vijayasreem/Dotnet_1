


using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;

namespace dotnet.Service
{
    public interface IUserRegistrationService
    {
        Task<int> CreateAsync(UserRegistrationModel user);
        Task<UserRegistrationModel> GetByIdAsync(int id);
        Task<IEnumerable<UserRegistrationModel>> GetAllAsync();
        Task<bool> UpdateAsync(UserRegistrationModel user);
        Task<bool> DeleteAsync(int id);
    }
}
