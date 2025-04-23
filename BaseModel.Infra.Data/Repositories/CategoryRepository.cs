using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class CategoryRepository : BaseTenantRepository<Category>, ICategoryRepository
    {

        public CategoryRepository(IHttpContextAccessor accessor, TenantDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }
        public void Add(Category category)
        {
            base.Add(category);
        }

        public void Remove(Category category)
        {
            base.SoftRemove(category);
        }

        public void Update(Category category)
        {
            base.Update(category);
        }
    }
}
