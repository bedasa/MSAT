using Com.MSAT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.MSAT.Infrastructure.Config
{
    public class OrderLineEntityTypeConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> orderLineConfiguration)
        {
            orderLineConfiguration.ToTable("OrderLines");
            orderLineConfiguration.HasKey(p => p.Id);
            orderLineConfiguration.Property(p => p.Id).UseIdentityColumn().HasColumnName("orderline_id");
            orderLineConfiguration.Property(p => p.OrderId).IsRequired()
                .HasColumnName("order_id");
            orderLineConfiguration.Property(p => p.ProductId).IsRequired()
                .HasColumnName("product_id");
            orderLineConfiguration.Property(p => p.CreatedBy).IsRequired().HasColumnName("created_by");
            orderLineConfiguration.Property(p => p.CreatedAt).IsRequired().HasColumnName("created_at");
            orderLineConfiguration.Property(p => p.UpdatedBy).IsRequired().HasColumnName("updated_by");
            orderLineConfiguration.Property(p => p.UpdatedAt).IsRequired().HasColumnName("updated_at");

            orderLineConfiguration.HasOne(o => o.ProductItem)
                .WithMany()
                .HasForeignKey(o => o.ProductId);

        }
    }
}