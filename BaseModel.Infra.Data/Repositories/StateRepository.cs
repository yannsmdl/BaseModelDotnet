using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class StateRepository : BaseAuthenticationRepository<State>, IStateRepository
    {

        public StateRepository(IHttpContextAccessor accessor, AuthenticationDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(State State)
        {
            base.Add(State);
        }

        public void Remove(State State)
        {
            base.SoftRemove(State);
        }

        public void Update(State State)
        {
            base.Update(State);
        }

        public async Task<State?> GetByName(string name)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.Name == name).FirstOrDefaultAsync();
        }
    }
}
