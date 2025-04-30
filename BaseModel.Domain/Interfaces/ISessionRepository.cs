namespace BaseModel.Domain.Interfaces
{
    public interface ISessionRepository
    {
        Task SaveSession(string userId, string token, Guid TenantId);
        Task InvalidateSession(string token);
    }
}