
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BaseModel.Infra.IoC
{
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    SaveSigninToken = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = async context =>
                    {
                        var dbContext = context.HttpContext.RequestServices.GetRequiredService<AuthenticationDbContext>();
                        var rawToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                        var session = await dbContext.Sessions
                            .FirstOrDefaultAsync(s => s.Token == rawToken);

                        if (session == null || session.RevokedAt != null)
                        {
                            context.Fail("Token revogado ou sessão não encontrada.");
                            return;
                        }

                        var tenantUrlReceived = context.Request.Headers["X-Tenant-Url"].ToString();

                        var tenantReceived = await dbContext.Tenants.FirstOrDefaultAsync(s => s.TenantUrl == tenantUrlReceived);
                        if (tenantReceived == null)
                        {
                            context.Fail("Tenant recebido não é valido");
                            return;
                        }

                        if (tenantReceived.Id != session.TenantId)
                        {
                            context.Fail("Tenant recebido não é o mesmo da sessão");
                            return;
                        }

                        var user = await dbContext.Users.FirstOrDefaultAsync(s => s.Id == session.UserId);
                        if (user == null)
                        {
                            context.Fail("Token revogado ou sessão não encontrada.");
                            return;
                        }
                    }
                };
            });
            return services;
        }
    }
}