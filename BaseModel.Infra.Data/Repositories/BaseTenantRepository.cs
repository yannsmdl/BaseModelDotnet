using System.Security.Claims;
using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace BaseModel.Infra.Data.Repositories
{
    public class BaseTenantRepository<T> where T : EntityBase
    {
        protected readonly Guid _loggedUserId;
        protected readonly TenantDbContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseTenantRepository(
            IHttpContextAccessor httpContextAccessor,
            TenantDbContext context)
        {
            _loggedUserId = Guid.Empty;
            Db = context;
            DbSet = Db.Set<T>();

            var user = httpContextAccessor.HttpContext?.User;

            if (user?.Identity?.IsAuthenticated == true)
            {
                var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
                {
                    _loggedUserId = userId;
                }
            }
        }

        public IUnitOfWork UnitOfWork => Db;

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await DbSet.Where(e=> e.DeletedAt == null).ToListAsync();
        }

        public virtual async Task<T?> GetById(Guid id)
        {
            return await DbSet.Where(e=> e.DeletedAt == null && e.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<List<T>> GetByIds(List<Guid> ids)
        {
            return await DbSet.Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public virtual void Add(T entity)
        {
            entity.SetCreation(_loggedUserId);
            DbSet.Add(entity);
        }

        public void SoftRemove(T entity)
        {
            entity.SetDeletion(_loggedUserId);

            bool tracking = Db.ChangeTracker.Entries<T>().Any(x => x.Entity.Id == entity.Id);
            if (!tracking)
                DbSet.Update(entity);
        }

        public void HardRemove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            entity.SetAlteration(_loggedUserId);
            DbSet.Update(entity);
        }
    }
}