using BaseModel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace BaseModel.Infra.Data.Context
{
    public class TenantDbContextRouteFactory : ITenantDbContextRouteFactory
    {
        public async Task<IUnitOfWork> CreateAndMigrateDbContextAsync(string connectionString, CancellationToken cancellationToken)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            var tenantDbContext = new TenantDbContext(optionsBuilder.Options, tenantProvider: null);

            await tenantDbContext.Database.MigrateAsync(cancellationToken);

            return tenantDbContext;
        }
    }
}