using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace DotNet.Repositories
{
    public class UserRegistrationRepository : IUserRegistrationService
    {
        private readonly string connectionString;

        public UserRegistrationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateAsync(UserRegistrationModel user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "INSERT INTO Users (Username, FirstName, LastName, EmailAddress, MobileNumber, PhoneNumber, Role, Level, Notes, IsActive) " +
                            "VALUES (@Username, @FirstName, @LastName, @EmailAddress, @MobileNumber, @PhoneNumber, @Role, @Level, @Notes, @IsActive);" +
                            "SELECT LAST_INSERT_ID();";

                var parameters = new
                {
                    user.Username,
                    user.FirstName,
                    user.LastName,
                    user.EmailAddress,
                    user.MobileNumber,
                    user.PhoneNumber,
                    user.Role,
                    user.Level,
                    user.Notes,
                    user.IsActive
                };

                var id = await connection.ExecuteScalarAsync<int>(query, parameters);
                return id;
            }
        }

        public async Task<UserRegistrationModel> GetByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM Users WHERE Id = @Id;";
                var parameters = new { Id = id };

                var user = await connection.QuerySingleOrDefaultAsync<UserRegistrationModel>(query, parameters);
                return user;
            }
        }

        public async Task<IEnumerable<UserRegistrationModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "SELECT * FROM Users;";

                var users = await connection.QueryAsync<UserRegistrationModel>(query);
                return users;
            }
        }

        public async Task<bool> UpdateAsync(UserRegistrationModel user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "UPDATE Users SET Username = @Username, FirstName = @FirstName, LastName = @LastName, " +
                            "EmailAddress = @EmailAddress, MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, " +
                            "Role = @Role, Level = @Level, Notes = @Notes, IsActive = @IsActive WHERE Id = @Id;";

                var parameters = new
                {
                    user.Id,
                    user.Username,
                    user.FirstName,
                    user.LastName,
                    user.EmailAddress,
                    user.MobileNumber,
                    user.PhoneNumber,
                    user.Role,
                    user.Level,
                    user.Notes,
                    user.IsActive
                };

                var rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var query = "DELETE FROM Users WHERE Id = @Id;";
                var parameters = new { Id = id };

                var rowsAffected = await connection.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
        }
    }
}