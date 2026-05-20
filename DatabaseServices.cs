namespace Edutastic;

using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Edutastic.Models;

public class DatabaseService
{
    private readonly string connectionString =
        "server=10.0.2.2;port=3306;database=edutastic;user=root;password=;";

    public async Task<User?> GetUser(string username, string password)
    {
        using var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync();

        string query = "SELECT * FROM user WHERE username=@username AND password=@password";

        using var command = new MySqlCommand(query, connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);

        using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new User
            {
                Id = Convert.ToInt32(reader["id"]),
                Username = reader["username"].ToString(),
                Password = reader["password"].ToString(),
                Email = reader["email"].ToString(),
                Streak = Convert.ToInt32(reader["streak"]),
                Points = Convert.ToInt32(reader["points"])
            };
        }

        return null;
    }
}