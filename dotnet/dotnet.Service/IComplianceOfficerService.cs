public interface IComplianceOfficerService
{
    Task<int> AddAsync(ComplianceOfficerModel model);
    Task<int> UpdateAsync(ComplianceOfficerModel model);
    Task<int> DeleteAsync(int id);
    Task<ComplianceOfficerModel> GetByIdAsync(int id);
    Task<List<ComplianceOfficerModel>> GetAllAsync();
}