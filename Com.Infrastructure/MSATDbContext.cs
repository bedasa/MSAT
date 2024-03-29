using Com.MSAT.Domain.Models;
using Com.MSAT.Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Com.MSAT.Infrastructure;

public class MsatDbContext : DbContext
{
    public DbSet<Product>? Products { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Order>? Orders { get; set; }
    public DbSet<Order>? OrderLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new OrderLineEntityTypeConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(
            "Server=tcp:msat.database.windows.net,1433;Initial Catalog=MSATSouce;Persist Security Info=False;User ID=bedasa;Password=$Pintu05006$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
    }
}