﻿using Com.MSAT.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Com.MSAT.Infrastructure.Config;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> orderConfiguration)
    {
        orderConfiguration.ToTable("Orders");
        orderConfiguration.HasKey(p => p.Id);
        orderConfiguration.Property(p => p.Id).UseIdentityColumn().HasColumnName("order_id");
        orderConfiguration.Property(p => p.CustomerName).IsRequired().HasMaxLength(100).HasColumnName("customer_name");
        orderConfiguration.Property(p => p.OrderDate).IsRequired().HasColumnName("order_date");
        orderConfiguration.Property(p => p.CreatedBy).IsRequired().HasColumnName("created_by");
        orderConfiguration.Property(p => p.CreatedAt).IsRequired().HasColumnName("created_at");
        orderConfiguration.Property(p => p.UpdatedBy).IsRequired().HasColumnName("updated_by");
        orderConfiguration.Property(p => p.UpdatedAt).IsRequired().HasColumnName("updated_at");
        orderConfiguration.HasMany(p => p.OrderLines)
            .WithOne(p => p.ParentOrder)
            .HasForeignKey(p => p.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}