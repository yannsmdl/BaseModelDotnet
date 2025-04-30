namespace BaseModel.Domain.Interfaces
{
    public interface IDatabaseManager
    {
        Task DropDatabaseAsync(string connectionString);
    }
}