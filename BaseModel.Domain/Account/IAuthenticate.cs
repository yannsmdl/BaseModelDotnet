using BaseModel.Domain.DTOs;

namespace BaseModel.Domain.Account
{
    public interface IAuthenticate
    {
        Task<UserTokenDTO?> Authenticate(string email, string password);
        Task<UserTokenDTO?> RegisterUser(string email, string password);
        Task Logout();
    }
}
