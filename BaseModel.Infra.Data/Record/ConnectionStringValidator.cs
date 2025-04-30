using System.Text.RegularExpressions;
using BaseModel.Domain.DTOs;
using BaseModel.Domain.Interfaces;
using Npgsql;

namespace BaseModel.Infra.Data.Record
{
    public class ConnectionStringValidator : IConnectionStringValidator
    {
        public bool IsValidConnectionString(string connectionString)
        {
            if (!IsConnectionStringStructureValid(connectionString))
            {
                return false;
            }

            return true;
        }

        public ConnectionStringDTO GetHostAndDatabaseFromConnectionString(string connectionString)
        {
            var host = GetValueFromConnectionString(connectionString, "Host");
            var database = GetValueFromConnectionString(connectionString, "Database");
            
            return new ConnectionStringDTO(){
                Host = host,
                DbName = database
            };
        }

        private string GetValueFromConnectionString(string connectionString, string key)
        {
            var keyWithEqualSign = key + "=";
            var startIndex = connectionString.IndexOf(keyWithEqualSign);
            
            if (startIndex == -1)
                throw new ArgumentException($"Key '{key}' not found in connection string.");
            
            startIndex += keyWithEqualSign.Length;
            var endIndex = connectionString.IndexOf(";", startIndex);
            
            if (endIndex == -1)
                endIndex = connectionString.Length;

            return connectionString.Substring(startIndex, endIndex - startIndex);
        }

        private bool IsConnectionStringStructureValid(string connectionString)
        {
            string pattern = @"^Host=[^;]+;Port=\d{4};Database=[^;]+;Username=[^;]+;Password=[^;]+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(connectionString);
        }

        public bool TestConnectionString(string connectionString)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}