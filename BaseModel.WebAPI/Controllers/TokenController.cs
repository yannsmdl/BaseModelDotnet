using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BaseModel.Domain.Account;
using BaseModel.Domain.DTOs;
using BaseModel.WebAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BaseModel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : BaseController
    {
        private readonly IAuthenticate _authentication;
        public TokenController
        (
            IAuthenticate authentication
        )
        {
            _authentication = authentication;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] LoginViewModel loginModel)
        {
            var userToken = await _authentication.Authenticate(loginModel.Email, loginModel.Password);
            if (userToken != null) return userToken;
            ModelState.AddModelError(string.Empty, "Invalid login attempt (password must be strong).");
            return BadRequest(ModelState);
        }

        [HttpPatch("Logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _authentication.Logout();
            return Ok(new { message = "Logout realizado com sucesso." });
        }
    }
}