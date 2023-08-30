


using dotnet.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet.Service
{
    public interface IComplianceOfficerService
    {
        Task<int> AddAsync(ComplianceOfficerModel model);
        Task<int> UpdateAsync(ComplianceOfficerModel model);
        Task<int> DeleteAsync(int id);
        Task<ComplianceOfficerModel> GetByIdAsync(int id);
        Task<List<ComplianceOfficerModel>> GetAllAsync();
    }
}
