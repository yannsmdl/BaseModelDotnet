using BaseModel.Domain.Account;
using BaseModel.Domain.DTOs;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;

namespace BaseModel.Infra.Data.Services
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly SignInManager<BaseUser> _signInManager;
        private readonly ITokenProvider _tokenProvider;
        private readonly ISessionRepository _sessionRepository;
        public AuthenticateService
        (
            UserManager<BaseUser> userManager,
            SignInManager<BaseUser> signInManager,
            ITokenProvider tokenProvider,
            ISessionRepository sessionRepository
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenProvider = tokenProvider;
            _sessionRepository = sessionRepository;
        }
        public async Task<UserTokenDTO?> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded) return null;

            var user = await _userManager.FindByEmailAsync(email);
            var userToken = _tokenProvider.GenerateToken(new BaseUserDTO(){
                Id = user.Id,
                Email = user.Email
            });

            await _sessionRepository.SaveSession(user.Id ,userToken.Token);

            return userToken;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
            var token = _tokenProvider.GetToken();
            if (!string.IsNullOrWhiteSpace(token))
            {
                await _sessionRepository.InvalidateSession(token);
            }
        }

        public async Task<UserTokenDTO?> RegisterUser(string email, string password)
        {
            var BaseUser = new BaseUser
            {
                UserName = email,
                Email = email,
            };
            var result = await _userManager.CreateAsync( BaseUser, password);
            if (result.Succeeded)
            {
                return await this.Authenticate(email, password);
            }
            return null;
        }
    }
}
