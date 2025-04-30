using BaseModel.Domain.DTOs;

namespace BaseModel.Domain.Interfaces
{
    public interface IConnectionStringValidator
    {
        bool IsValidConnectionString(string connectionString);
        bool TestConnectionString(string connectionString);
        ConnectionStringDTO GetHostAndDatabaseFromConnectionString(string connectionString);
    }
}