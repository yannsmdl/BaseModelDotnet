using BaseModel.Domain.Entities;
using BaseModel.Infra.Data.EntitiesConfiguration;
using BaseModel.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Messaging;

namespace BaseModel.Infra.Data.Context
{
    public class AuthenticationDbContext : IdentityDbContext<BaseUser>, IUnitOfWork
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Profession> Professions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Ignore<Event>();
            builder.ApplyConfiguration(new TenantConfiguration());
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}