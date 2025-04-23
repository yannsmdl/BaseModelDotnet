using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BaseModel.Infra.IoC
{
    public static class DependencyInjectionMultiTenant
    {
        public static IServiceCollection AddInfrastructureMultiTenantT(this IServiceCollection services)
        {
            services.AddScoped<TenantDbContext>(provider =>
            {
                var tenantProvider = provider.GetRequiredService<ITenantProvider>();
                var tenant = tenantProvider.GetCurrentTenant();
                var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
                optionsBuilder.UseNpgsql(tenant.ConnectionString);
                return new TenantDbContext(optionsBuilder.Options, tenantProvider);
            });
            return services;
        }
    }
}