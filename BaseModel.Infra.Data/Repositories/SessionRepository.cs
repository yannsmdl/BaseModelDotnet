using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BaseModel.Infra.Data.Repositories
{
    public class SessionRepository : BaseAuthenticationRepository<Session>, ISessionRepository
    {

        public SessionRepository(IHttpContextAccessor accessor, AuthenticationDbContext context)
        : base(accessor, context) {}

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task InvalidateSession(string token)
        {
            var session = await DbSet.FirstOrDefaultAsync(s => s.Token == token);
            if (session != null)
            {
                session.Revoke();
                await Db.SaveChangesAsync();
            }
        }

        public async Task SaveSession(string userId, string token, Guid tenantId)
        {
            var activeSessions = await DbSet
                .Where(s => s.UserId == userId && s.TenantId == tenantId && s.RevokedAt == null)
                .ToListAsync();

            foreach (var session in activeSessions)
            {
                session.Revoke();
            }

            var newSession = new Session(Guid.NewGuid(), userId, token, tenantId);
            DbSet.Add(newSession);

            await Db.SaveChangesAsync();
        }
    }
}