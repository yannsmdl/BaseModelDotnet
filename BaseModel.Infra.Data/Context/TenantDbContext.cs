using BaseModel.Domain.Entities;
using BaseModel.Domain.Interfaces;
using BaseModel.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using NetDevPack.Messaging;

namespace BaseModel.Infra.Data.Context
{
    public class TenantDbContext : DbContext, IUnitOfWork
    {
        private readonly ITenantProvider _tenantProvider;
        public TenantDbContext(DbContextOptions<TenantDbContext> options, ITenantProvider tenantProvider)
            : base(options)
        {
            _tenantProvider = tenantProvider;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<AddressClient> AddressClients { get; set; }
        public DbSet<EmailClient> EmailClients { get; set; }
        public DbSet<PhoneClient> PhoneClients { get; set; }
        public DbSet<Client> Clients { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_tenantProvider != null && !optionsBuilder.IsConfigured)
            {
                var tenant = _tenantProvider.GetCurrentTenant();
                optionsBuilder.UseNpgsql(tenant.ConnectionString);
            } 
        }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
