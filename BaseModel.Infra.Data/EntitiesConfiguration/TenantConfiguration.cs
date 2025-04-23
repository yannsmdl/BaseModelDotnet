using BaseModel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseModel.Infra.Data.EntitiesConfiguration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(255).IsRequired();
        builder.Property(t => t.ConnectionString).HasMaxLength(500).IsRequired();
        builder.Property(t => t.TenantUrl).HasMaxLength(255);
        builder.Property(t => t.IsActive).HasDefaultValue(true);

        builder.HasData(
            new Tenant(
                new Guid("11111111-1111-1111-1111-111111111111"),
                "TenantA",
                "Host=localhost;Database=yann_dotnet;Username=postgres;Password=postgres",
                "http://tenant-a.com"
            ),
            new Tenant(
                new Guid("22222222-2222-2222-2222-222222222222"),
                "TenantB",
                "Host=localhost;Database=tenant_b;Username=postgres;Password=postgres",
                "http://tenant-b.com"
            ),
            new Tenant(
                new Guid("33333333-3333-3333-3333-333333333333"),
                "TenantC",
                "Host=localhost;Database=tenant_c;Username=postgres;Password=postgres",
                "http://tenant-c.com"
            )
        );
    }
}
}