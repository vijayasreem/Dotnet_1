using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace dotnet
{
    public class UserModelRepository : IUserModelRepository
    {
        private readonly string connectionString;

        public UserModelRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateUser(UserModel user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("INSERT INTO Users (Username, FirstName, LastName, EmailAddress, MobileNumber, PhoneNumber, Role, Level, Notes, IsActive) " +
                    "VALUES (@Username, @FirstName, @LastName, @EmailAddress, @MobileNumber, @PhoneNumber, @Role, @Level, @Notes, @IsActive)", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Level", user.Level);
                command.Parameters.AddWithValue("@Notes", user.Notes);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<UserModel> GetUserById(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new UserModel
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            EmailAddress = reader.GetString("EmailAddress"),
                            MobileNumber = reader.GetString("MobileNumber"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            Role = reader.GetString("Role"),
                            Level = reader.GetString("Level"),
                            Notes = reader.GetString("Notes"),
                            IsActive = reader.GetBoolean("IsActive")
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("SELECT * FROM Users", connection);

                var users = new List<UserModel>();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        users.Add(new UserModel
                        {
                            Id = reader.GetInt32("Id"),
                            Username = reader.GetString("Username"),
                            FirstName = reader.GetString("FirstName"),
                            LastName = reader.GetString("LastName"),
                            EmailAddress = reader.GetString("EmailAddress"),
                            MobileNumber = reader.GetString("MobileNumber"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            Role = reader.GetString("Role"),
                            Level = reader.GetString("Level"),
                            Notes = reader.GetString("Notes"),
                            IsActive = reader.GetBoolean("IsActive")
                        });
                    }
                }

                return users;
            }
        }

        public async Task<int> UpdateUser(UserModel user)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("UPDATE Users SET Username = @Username, FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, " +
                    "MobileNumber = @MobileNumber, PhoneNumber = @PhoneNumber, Role = @Role, Level = @Level, Notes = @Notes, IsActive = @IsActive WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
                command.Parameters.AddWithValue("@MobileNumber", user.MobileNumber);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@Role", user.Role);
                command.Parameters.AddWithValue("@Level", user.Level);
                command.Parameters.AddWithValue("@Notes", user.Notes);
                command.Parameters.AddWithValue("@IsActive", user.IsActive);
                command.Parameters.AddWithValue("@Id", user.Id);

                return await command.ExecuteNonQueryAsync();
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                var command = new MySqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}