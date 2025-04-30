using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class TenantRepository : BaseAuthenticationRepository<Tenant>, ITenantRepository
    {

        public TenantRepository(IHttpContextAccessor accessor, AuthenticationDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(Tenant Tenant)
        {
            base.Add(Tenant);
        }

        public void Remove(Tenant Tenant)
        {
            base.SoftRemove(Tenant);
        }

        public void Update(Tenant Tenant)
        {
            base.Update(Tenant);
        }

        public async Task<Tenant?> GetByTenantUrl(string tenantUrl)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.TenantUrl == tenantUrl).FirstOrDefaultAsync();
        }

        public async Task<Tenant?> GetByDbName(string host, string dbName)
        {
            return await DbSet
            .Where(e => e.DeletedAt == null 
                        && e.ConnectionString.Contains($"Host={host};") 
                        && e.ConnectionString.Contains($"Database={dbName};"))
            .FirstOrDefaultAsync();
        }
    }
}
