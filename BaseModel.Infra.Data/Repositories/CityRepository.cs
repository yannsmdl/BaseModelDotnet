using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class CityRepository : BaseAuthenticationRepository<City>, ICityRepository
    {

        public CityRepository(IHttpContextAccessor accessor, AuthenticationDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(City City)
        {
            base.Add(City);
        }

        public void Remove(City City)
        {
            base.SoftRemove(City);
        }

        public void Update(City City)
        {
            base.Update(City);
        }

        public async Task<IEnumerable<City>> GetByStateId(Guid stateId)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.StateId == stateId).ToListAsync();
        }
    }
}
