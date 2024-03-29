using Com.MSAT.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.MSAT.Infrastructure.Config;

public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> productConfiguration)
    {
        productConfiguration.ToTable("Products");
        productConfiguration.HasKey(p => p.Id);
        productConfiguration.Property(p => p.Id).UseIdentityColumn().HasColumnName("product_id");
        productConfiguration.Property(p => p.ProductName).IsRequired().HasMaxLength(100).HasColumnName("product_name");
        productConfiguration.Property(p => p.CategoryId).HasColumnName("category_id");
        productConfiguration.Property(p => p.Price).IsRequired().HasColumnName("price");
        productConfiguration.Property(p => p.Description).HasMaxLength(200).HasColumnName("description");
        productConfiguration.Property(p => p.ImageUrl).HasColumnName("image_url")
            .HasMaxLength(2083); // taken as lowest form all the browsers
        productConfiguration.Property(p => p.DateAdded).IsRequired().HasColumnName("date_added");
        productConfiguration.Property(p => p.CreatedBy).IsRequired().HasColumnName("created_by");
        productConfiguration.Property(p => p.CreatedAt).IsRequired().HasColumnName("created_at");
        productConfiguration.Property(p => p.UpdatedBy).IsRequired().HasColumnName("updated_by");
        productConfiguration.Property(p => p.UpdatedAt).IsRequired().HasColumnName("updated_at");

        //  Product class has a CategoryId field and a Category navigation property
        productConfiguration.HasOne(p => p.ProductCategory)
            .WithMany()
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();
    }
}