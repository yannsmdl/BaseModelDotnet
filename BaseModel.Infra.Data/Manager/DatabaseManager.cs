using BaseModel.Domain.Interfaces;
using Npgsql;

namespace BaseModel.Infra.Data.Manager
{
    public class DatabaseManager : IDatabaseManager
    {
        public async Task DropDatabaseAsync(string connectionString)
        {
            var builder = new NpgsqlConnectionStringBuilder(connectionString);

            var dbName = builder.Database;

            var systemDbConnection = new NpgsqlConnectionStringBuilder
            {
                Host = builder.Host,
                Port = builder.Port,
                Username = builder.Username,
                Password = builder.Password,
                Database = "postgres", // conecta no banco postgres
                SslMode = builder.SslMode,
                TrustServerCertificate = builder.TrustServerCertificate
            };

            await using var connection = new NpgsqlConnection(systemDbConnection.ConnectionString);
            await connection.OpenAsync();

            var commandText = $"DROP DATABASE IF EXISTS \"{dbName}\";";

            await using var command = new NpgsqlCommand(commandText, connection);
            try 
            {
                await command.ExecuteNonQueryAsync();
            }
            catch(Exception error){}
        }
    }
}