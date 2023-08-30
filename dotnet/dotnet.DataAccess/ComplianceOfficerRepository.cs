using dotnet.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace dotnet.Repository
{
    public class ComplianceOfficerRepository : IComplianceOfficerService
    {
        private readonly string _connectionString;

        public ComplianceOfficerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddAsync(ComplianceOfficerModel model)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "INSERT INTO ComplianceOfficers (FirstName, MiddleName, LastName, DOB, Email, MobileNumber, PhoneNumber, Gender, Pan, Aadhar, OtherID, Organization, Notes) " +
                          "VALUES (@FirstName, @MiddleName, @LastName, @DOB, @Email, @MobileNumber, @PhoneNumber, @Gender, @Pan, @Aadhar, @OtherID, @Organization, @Notes)";

                var parameters = new
                {
                    model.FirstName,
                    model.MiddleName,
                    model.LastName,
                    model.DOB,
                    model.Email,
                    model.MobileNumber,
                    model.PhoneNumber,
                    model.Gender,
                    model.Pan,
                    model.Aadhar,
                    model.OtherID,
                    model.Organization,
                    model.Notes
                };

                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<int> UpdateAsync(ComplianceOfficerModel model)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "UPDATE ComplianceOfficers SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, DOB = @DOB, " +
                          "Email = @Email, MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, Gender = @Gender, Pan = @Pan, Aadhar = @Aadhar, " +
                          "OtherID = @OtherID, Organization = @Organization, Notes = @Notes WHERE Id = @Id";

                var parameters = new
                {
                    model.Id,
                    model.FirstName,
                    model.MiddleName,
                    model.LastName,
                    model.DOB,
                    model.Email,
                    model.MobileNumber,
                    model.PhoneNumber,
                    model.Gender,
                    model.Pan,
                    model.Aadhar,
                    model.OtherID,
                    model.Organization,
                    model.Notes
                };

                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "DELETE FROM ComplianceOfficers WHERE Id = @Id";

                var parameters = new { Id = id };

                return await connection.ExecuteAsync(sql, parameters);
            }
        }

        public async Task<ComplianceOfficerModel> GetByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT * FROM ComplianceOfficers WHERE Id = @Id";

                var parameters = new { Id = id };

                return await connection.QueryFirstOrDefaultAsync<ComplianceOfficerModel>(sql, parameters);
            }
        }

        public async Task<List<ComplianceOfficerModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT * FROM ComplianceOfficers";

                return (await connection.QueryAsync<ComplianceOfficerModel>(sql)).ToList();
            }
        }
    }
}