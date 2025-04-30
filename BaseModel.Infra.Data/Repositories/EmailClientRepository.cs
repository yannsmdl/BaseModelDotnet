using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class EmailClientRepository : BaseTenantRepository<EmailClient>, IEmailClientRepository
    {

        public EmailClientRepository(IHttpContextAccessor accessor, TenantDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(EmailClient EmailClient)
        {
            base.Add(EmailClient);
        }

        public void Remove(EmailClient EmailClient)
        {
            base.SoftRemove(EmailClient);
        }

        public void Update(EmailClient EmailClient)
        {
            base.Update(EmailClient);
        }


        public async Task<IEnumerable<EmailClient>> GetByClientId(Guid clientId)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.ClientId == clientId).ToListAsync();
        }
    }
}
