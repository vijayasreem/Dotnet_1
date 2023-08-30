


using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DTO;

namespace dotnet.Service
{
    public interface ISacralAiRepository
    {
        Task<int> AddAsync(SacralAiModel model);
        Task<SacralAiModel> GetByIdAsync(int id);
        Task<List<SacralAiModel>> GetAllAsync();
        Task UpdateAsync(SacralAiModel model);
        Task DeleteAsync(int id);
    }
}
