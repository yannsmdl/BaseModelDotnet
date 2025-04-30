using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class ClientRepository : BaseTenantRepository<Client>, IClientRepository
    {

        public ClientRepository(IHttpContextAccessor accessor, TenantDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(Client Client)
        {
            base.Add(Client);
        }

        public void Remove(Client Client)
        {
            base.SoftRemove(Client);
        }

        public void Update(Client Client)
        {
            base.Update(Client);
        }

        public async Task<Client?> GetByUserId(string userId)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
