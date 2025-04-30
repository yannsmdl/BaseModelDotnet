using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class PhoneClientRepository : BaseTenantRepository<PhoneClient>, IPhoneClientRepository
    {

        public PhoneClientRepository(IHttpContextAccessor accessor, TenantDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(PhoneClient PhoneClient)
        {
            base.Add(PhoneClient);
        }

        public void Remove(PhoneClient PhoneClient)
        {
            base.SoftRemove(PhoneClient);
        }

        public void Update(PhoneClient PhoneClient)
        {
            base.Update(PhoneClient);
        }


        public async Task<IEnumerable<PhoneClient>> GetByClientId(Guid clientId)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.ClientId == clientId).ToListAsync();
        }
    }
}
