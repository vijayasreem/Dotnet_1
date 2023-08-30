using dotnet.DTO;
using dotnet.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet.Service
{
    public class ComplianceOfficerService : IComplianceOfficerService
    {
        private readonly IComplianceOfficerRepository _repository;

        public ComplianceOfficerService(IComplianceOfficerRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(ComplianceOfficerModel model)
        {
            // Validate mandatory fields
            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.MobileNumber) || string.IsNullOrEmpty(model.Gender))
            {
                throw new ArgumentException("First Name, Email, Mobile Number, and Gender are mandatory fields.");
            }

            // Check identification proof
            if (string.IsNullOrEmpty(model.Pan) && string.IsNullOrEmpty(model.Aadhar))
            {
                throw new ArgumentException("Either PAN or Aadhaar is required as identification proof.");
            }

            return await _repository.AddAsync(model);
        }

        public async Task<int> UpdateAsync(ComplianceOfficerModel model)
        {
            // Validate mandatory fields
            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.MobileNumber) || string.IsNullOrEmpty(model.Gender))
            {
                throw new ArgumentException("First Name, Email, Mobile Number, and Gender are mandatory fields.");
            }

            // Check identification proof
            if (string.IsNullOrEmpty(model.Pan) && string.IsNullOrEmpty(model.Aadhar))
            {
                throw new ArgumentException("Either PAN or Aadhaar is required as identification proof.");
            }

            return await _repository.UpdateAsync(model);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ComplianceOfficerModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<ComplianceOfficerModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}