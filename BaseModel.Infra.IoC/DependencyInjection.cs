using BaseModel.Application.Interfaces;
using BaseModel.Application.Services;
using BaseModel.Domain.Account;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using BaseModel.Infra.Data.Identity;
using BaseModel.Infra.Data.Manager;
using BaseModel.Infra.Data.Record;
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

            services.AddScoped<ITenantDbContextRouteFactory, TenantDbContextRouteFactory>();
            services.AddScoped<IDatabaseManager, DatabaseManager>();

            #endregion

            #region Repository
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IAddressClientRepository, AddressClientRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IPhoneClientRepository, PhoneClientRepository>();
            services.AddScoped<IEmailClientRepository, EmailClientRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            
            #endregion

            #region Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
            services.AddScoped<ITenantProvider, TenantProvider>();
            services.AddScoped<ITokenProvider, TokenService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAddressClientService, AddressClientService>();
            services.AddScoped<IEmailClientService, EmailClientService>();
            services.AddScoped<IPhoneClientService, PhoneClientService>();
            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<IProfessionService, ProfessionService>();
            #endregion

            #region Record
            services.AddScoped<IConnectionStringValidator, ConnectionStringValidator>();
            #endregion

            return services;
        }
    }
}
