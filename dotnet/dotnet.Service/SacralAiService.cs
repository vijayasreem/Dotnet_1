using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet.DataAccess;
using dotnet.DTO;

namespace dotnet.Service
{
    public class SacralAiService : ISacralAiService
    {
        private readonly ISacralAiRepository _repository;

        public SacralAiService(ISacralAiRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(SacralAiModel model)
        {
            return await _repository.AddAsync(model);
        }

        public async Task<SacralAiModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<SacralAiModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task UpdateAsync(SacralAiModel model)
        {
            await _repository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}