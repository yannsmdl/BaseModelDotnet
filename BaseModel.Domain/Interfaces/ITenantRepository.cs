using BaseModel.Domain.Entities;
using NetDevPack.Data;

namespace BaseModel.Domain.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Task<IEnumerable<Tenant>> GetAll();
        Task<Tenant?> GetById(Guid Id);
        Task<Tenant?> GetByTenantUrl(string tenantUrl);
        Task<Tenant?> GetByDbName(string host, string dbName);
        void Add(Tenant category);
        void Update(Tenant category);
        void Remove(Tenant category);
    }
}
