public interface ISacralAiService
{
    Task<int> AddAsync(SacralAiModel model);
    Task<SacralAiModel> GetByIdAsync(int id);
    Task<List<SacralAiModel>> GetAllAsync();
    Task UpdateAsync(SacralAiModel model);
    Task DeleteAsync(int id);
}