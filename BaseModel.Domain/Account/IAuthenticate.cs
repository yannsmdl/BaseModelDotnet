using BaseModel.Domain.DTOs;

namespace BaseModel.Domain.Account
{
    public interface IAuthenticate
    {
        Task<UserTokenDTO?> Authenticate(string email, string password);
        Task<bool> RegisterUser(string Id, string email, string password, Guid tenantId);
        Task Logout();
        Task<bool> Commit();
        Task<bool> ExistsUserByEmail(string email, string id);
        Task<bool> UpdateEmailUser(string id, string email);
        Task<Guid> GetTenantIdByUserId(string id);
        Task<bool> DeleteUser(string id);
    }
}
