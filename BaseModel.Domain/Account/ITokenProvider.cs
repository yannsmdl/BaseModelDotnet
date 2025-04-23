using BaseModel.Domain.DTOs;

namespace BaseModel.Domain.Account
{
    public interface ITokenProvider
    {
        UserTokenDTO GenerateToken(BaseUserDTO user);
    }
}