using BaseModel.Application.Interfaces;
using BaseModel.Application.Services;
using BaseModel.Domain.Account;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using BaseModel.Infra.Data.Identity;
using BaseModel.Infra.Data.Repositories;
using BaseModel.Infra.Data.Services;
using BaseModel.Infra.Ioc.Mappings;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseModel.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureAPI(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            #region Configs
            services.AddDbContext<AuthenticationDbContext>
                (options => options.UseNpgsql(configuration.GetConnectionString("AuthenticationConnection")
                , b => b.MigrationsAssembly(typeof(AuthenticationDbContext).Assembly.FullName)));
            services.AddDbContext<TenantDbContext>
                (options => options.UseNpgsql(configuration.GetConnectionString("TenantConnection")
                , b => b.MigrationsAssembly(typeof(TenantDbContext).Assembly.FullName)));
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("BaseModel.Application");
            services.AddMediatR(myhandlers);

            services.AddIdentity<BaseUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthenticationDbContext>()
                .AddDefaultTokenProviders();

            #endregion

            #region Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            
            #endregion

            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<ITenantProvider, TenantProvider>();
            services.AddScoped<ITokenProvider, TokenService>();
            #endregion


            return services;
        }
    }
}
