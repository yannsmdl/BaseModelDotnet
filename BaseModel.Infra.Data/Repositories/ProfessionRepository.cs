using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class ProfessionRepository : BaseAuthenticationRepository<Profession>, IProfessionRepository
    {

        public ProfessionRepository(IHttpContextAccessor accessor, AuthenticationDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(Profession Profession)
        {
            base.Add(Profession);
        }

        public void Remove(Profession Profession)
        {
            base.SoftRemove(Profession);
        }

        public void Update(Profession Profession)
        {
            base.Update(Profession);
        }

        public async Task<Profession?> GetByName(string name)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.Name == name).FirstOrDefaultAsync();
        }
    }
}
