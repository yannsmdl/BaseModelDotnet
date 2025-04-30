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
                "ClientA",
                "Host=localhost;Database=new_erp_client_a_dotnet;Username=postgres;Password=postgres",
                "client-a"
            )
        );
    }
}
}