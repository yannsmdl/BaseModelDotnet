using BaseModel.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace BaseModel.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial
        (
            UserManager<BaseUser> userManager,
            RoleManager<IdentityRole> roleManage
        )
        {
            _userManager = userManager;
            _roleManager = roleManage;
        }
        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Manager").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Manager";
                role.NormalizedName = "MANAGER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("user@localhost").Result == null)
            {
                BaseUser user = new BaseUser();
                user.UserName = "user@localhost";
                user.Email = "user@localhost";
                user.NormalizedUserName = "USER@LOCALHOST";
                user.NormalizedEmail = "USER@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Teste@123456789").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
            if (_userManager.FindByEmailAsync("manager@localhost").Result == null)
            {
                BaseUser user = new BaseUser();
                user.UserName = "manager@localhost";
                user.Email = "manager@localhost";
                user.NormalizedUserName = "MANAGER@LOCALHOST";
                user.NormalizedEmail = "MANAGER@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Teste@123456789").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                BaseUser user = new BaseUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Teste#147258369").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
