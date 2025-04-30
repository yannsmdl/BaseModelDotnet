using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class AddressClientRepository : BaseTenantRepository<AddressClient>, IAddressClientRepository
    {

        public AddressClientRepository(IHttpContextAccessor accessor, TenantDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(AddressClient AddressClient)
        {
            base.Add(AddressClient);
        }

        public void Remove(AddressClient AddressClient)
        {
            base.SoftRemove(AddressClient);
        }

        public void Update(AddressClient AddressClient)
        {
            base.Update(AddressClient);
        }


        public async Task<IEnumerable<AddressClient>> GetByClientId(Guid clientId)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.ClientId == clientId).ToListAsync();
        }
    }
}
