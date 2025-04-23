namespace BaseModel.Domain.Interfaces
{
    public interface ISessionRepository
    {
        Task SaveSession(string userId, string token);
        Task InvalidateSession(string token);
    }
}