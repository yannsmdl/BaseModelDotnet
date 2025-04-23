using BaseModel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseModel.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(255).IsRequired();

            builder.HasData(
                new Category(new Guid("368ca675-d0a1-4570-9e66-8c98ddf41714"), "Eletrônicos"),
                new Category(new Guid("2d6f83c2-1dcd-4b90-9ed6-68eaa6311798"), "Moveis")
            );
        }
    }
}
