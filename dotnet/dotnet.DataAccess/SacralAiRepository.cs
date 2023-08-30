using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using dotnet.DTO;

namespace dotnet
{
    public class SacralAiRepository : ISacralAiRepository
    {
        private readonly string _connectionString;

        public SacralAiRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<int> AddAsync(SacralAiModel model)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO SacralAi (GitHubUsername, GitHubPassword, GitHubURL, RepositoryName) " +
                            "VALUES (@GitHubUsername, @GitHubPassword, @GitHubURL, @RepositoryName); " +
                            "SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GitHubUsername", model.GitHubUsername);
                    command.Parameters.AddWithValue("@GitHubPassword", model.GitHubPassword);
                    command.Parameters.AddWithValue("@GitHubURL", model.GitHubURL);
                    command.Parameters.AddWithValue("@RepositoryName", model.RepositoryName);

                    var id = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(id);
                }
            }
        }

        public async Task<SacralAiModel> GetByIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM SacralAi WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new SacralAiModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                GitHubUsername = reader["GitHubUsername"].ToString(),
                                GitHubPassword = reader["GitHubPassword"].ToString(),
                                GitHubURL = reader["GitHubURL"].ToString(),
                                RepositoryName = reader["RepositoryName"].ToString()
                            };
                        }

                        return null;
                    }
                }
            }
        }

        public async Task<List<SacralAiModel>> GetAllAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT * FROM SacralAi";

                using (var command = new MySqlCommand(query, connection))
                {
                    var models = new List<SacralAiModel>();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            models.Add(new SacralAiModel
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                GitHubUsername = reader["GitHubUsername"].ToString(),
                                GitHubPassword = reader["GitHubPassword"].ToString(),
                                GitHubURL = reader["GitHubURL"].ToString(),
                                RepositoryName = reader["RepositoryName"].ToString()
                            });
                        }
                    }

                    return models;
                }
            }
        }

        public async Task UpdateAsync(SacralAiModel model)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE SacralAi SET GitHubUsername = @GitHubUsername, " +
                            "GitHubPassword = @GitHubPassword, GitHubURL = @GitHubURL, RepositoryName = @RepositoryName " +
                            "WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@GitHubUsername", model.GitHubUsername);
                    command.Parameters.AddWithValue("@GitHubPassword", model.GitHubPassword);
                    command.Parameters.AddWithValue("@GitHubURL", model.GitHubURL);
                    command.Parameters.AddWithValue("@RepositoryName", model.RepositoryName);
                    command.Parameters.AddWithValue("@Id", model.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "DELETE FROM SacralAi WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}