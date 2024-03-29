using Com.MSAT.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.MSAT.Infrastructure.Config;

public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> categoryConfiguration)
    {
        categoryConfiguration.ToTable("Categories");
        categoryConfiguration.HasKey(p => p.Id);
        categoryConfiguration.Property(p => p.Id).UseIdentityColumn().HasColumnName("category_id");
        categoryConfiguration.Property(p => p.CategoryName).IsRequired().HasMaxLength(50)
            .HasColumnName("category_name");
        categoryConfiguration.Property(p => p.CreatedBy).IsRequired().HasColumnName("created_by");
        categoryConfiguration.Property(p => p.CreatedAt).IsRequired().HasColumnName("created_at");
        categoryConfiguration.Property(p => p.UpdatedBy).IsRequired().HasColumnName("updated_by");
        categoryConfiguration.Property(p => p.UpdatedAt).IsRequired().HasColumnName("updated_at");
    }
}