using Com.MSAT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.MSAT.Infrastructure.Config;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> orderConfiguration)
    {
        var navigation = orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderLines));
        navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);
        
        orderConfiguration.ToTable("Orders");
        orderConfiguration.HasKey(p => p.Id);
        orderConfiguration.Property(p => p.Id).UseIdentityColumn().HasColumnName("order_id");
        orderConfiguration.Property(p => p.CustomerName).IsRequired().HasMaxLength(100).HasColumnName("customer_name");
        orderConfiguration.Property(p => p.OrderDate).IsRequired().HasColumnName("order_date");
        orderConfiguration.Property(p => p.CreatedBy).IsRequired().HasColumnName("created_by");
        orderConfiguration.Property(p => p.CreatedAt).IsRequired().HasColumnName("created_at");
        orderConfiguration.Property(p => p.UpdatedBy).IsRequired().HasColumnName("updated_by");
        orderConfiguration.Property(p => p.UpdatedAt).IsRequired().HasColumnName("updated_at");
        
    }
}