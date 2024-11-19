using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Orders.Domain.Model.Aggregates;

namespace ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
   
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        //Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AdminStock>().ToTable("admin_stocks").HasKey(a => a.Id);
        builder.Entity<AdminStock>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<AdminStock>().Property(a => a.Date).IsRequired();
        builder.Entity<AdminStock>().Property(a => a.Ingredient).IsRequired();
        builder.Entity<AdminStock>().Property(a => a.Quantity).IsRequired();
        builder.Entity<AdminStock>().Property(a => a.Supplier).HasColumnName("Supplier").IsRequired();
        builder.Entity<AdminStock>().Ignore(a => a.SupplierNameValue);

        builder.Entity<Order>().ToTable("orders").HasKey(a => a.Id);
        builder.Entity<Order>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Order>().Property(a => a.Cash).IsRequired();
        builder.Entity<Order>().Property(a => a.Name).IsRequired();
        builder.Entity<Order>().Property(a => a.Table).IsRequired();
        builder.Entity<Order>().Property(a => a.Time).IsRequired();
        builder.Entity<Order>().Property(a => a.Status).IsRequired();
        builder.Entity<Order>().Property(a => a.Quantity).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}

