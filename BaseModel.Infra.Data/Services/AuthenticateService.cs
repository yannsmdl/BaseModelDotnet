using BaseModel.Domain.Account;
using BaseModel.Domain.DTOs;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using BaseModel.Infra.Data.Identity;
using BaseModel.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Services
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly SignInManager<BaseUser> _signInManager;
        private readonly ITokenProvider _tokenProvider;
        private readonly ISessionRepository _sessionRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IPasswordHasher<BaseUser> _passwordHasher;
        private readonly AuthenticationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticateService
        (
            UserManager<BaseUser> userManager,
            SignInManager<BaseUser> signInManager,
            ITokenProvider tokenProvider,
            ISessionRepository sessionRepository,
            IPasswordHasher<BaseUser> passwordHasher,
            AuthenticationDbContext dbContext,
            IHttpContextAccessor httpContextAccessor,
            ITenantRepository tenantRepository,
            RoleManager<IdentityRole> roleManager
        )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenProvider = tokenProvider;
            _sessionRepository = sessionRepository;
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _tenantRepository = tenantRepository;
        }
        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new InvalidOperationException("Usuário não existe");
            
            _dbContext.Set<BaseUser>().Remove(user);
            return true;
        }
        public async Task<bool> ExistsUserByEmail(string email, string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;
            var userEmail = await _dbContext.Set<BaseUser>()
                .FirstOrDefaultAsync(u => u.Email == email && u.TenantId == user.TenantId);
            if (userEmail != null && userEmail.Id != user.Id) return false;
            return true;
        }
        public async Task<bool> UpdateEmailUser(string id, string email)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new InvalidOperationException("Usuário não existe");

            user.Email = email;
            user.UserName = email;
            user.NormalizedEmail = email.ToUpper();
            user.NormalizedUserName = email.ToUpper();

             _dbContext.Set<BaseUser>().Update(user);
             return true;
        }
        public async Task<UserTokenDTO?> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            if (!result.Succeeded) return null;

            var user = await _userManager.FindByEmailAsync(email);
            
            var roles = await _userManager.GetRolesAsync(user);
            if (roles == null || roles.Count == 0) return null;

            if (user.TenantId == null && "Admin" != roles.ElementAt(0).ToString()) return null;

            var tenantUrl = _httpContextAccessor.HttpContext?.Request.Headers["X-Tenant-Url"].ToString();
            if (string.IsNullOrWhiteSpace(tenantUrl)) return null;

            var tenant = await _tenantRepository.GetByTenantUrl(tenantUrl);
            if (tenant == null) return null;

            if (user.TenantId != null && user.TenantId != tenant.Id) return null;
            
            var userToken = _tokenProvider.GenerateToken(new BaseUserDTO(){
                Id = user.Id,
                Email = user.Email,
                Roles = roles.ToList(),
                Username = user.UserName,
                TenantId = tenant.Id
            });

            await _sessionRepository.SaveSession(user.Id ,userToken.Token, tenant.Id);

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

        public async Task<bool> RegisterUser(string Id, string email, string password, Guid tenantId)
        {
            var exists = await _dbContext.Set<BaseUser>()
                .AnyAsync(u => u.Email == email && u.TenantId == tenantId);

            if (exists) throw new InvalidOperationException("User already exists.");

            var user = new BaseUser
            {
                Id = Id,
                UserName = email,
                NormalizedEmail = email.ToUpper(),
                NormalizedUserName = email.ToUpper(),
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Email = email,
                PasswordHash = _passwordHasher.HashPassword(null, password),
                TenantId = tenantId
            };

            _dbContext.Set<BaseUser>().Add(user);

            var role = await _dbContext.Roles.FirstAsync(r => r.Name == "User");

            var userRole = new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = role.Id
            };

            _dbContext.Set<IdentityUserRole<string>>().Add(userRole);
            return true;
        }

        public async Task<bool> Commit()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<Guid> GetTenantIdByUserId(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) throw new InvalidOperationException("Usuário não existe.");
            return user.TenantId ?? Guid.Empty;
        }
    }
}
