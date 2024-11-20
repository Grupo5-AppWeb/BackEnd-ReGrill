using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using ReGrill.API.IAM.Domain.Model.Aggregates.Management;
using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
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
        
        
         // IAM Context
        
        /*builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired().HasMaxLength(25);
        builder.Entity<User>().Property(u => u.Email).IsRequired().HasMaxLength(35);
        // Will save the Role id in the Database because is a one-to-many relationship
        builder.Entity<User>().HasOne(u => u.Role).WithMany();
        builder.Entity<Role>(entity =>
        {
            entity.HasKey(r => r.Id);
            entity.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(r => r.Name).IsRequired().HasConversion<string>();
        });*/

        builder.Entity<Role>(a =>
        {
            a.HasKey(r => r.Id);
            a.Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            a.Property(r => r.Name).IsRequired().HasConversion<string>();
        });

       
        
        builder.Entity<Administrator>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(u => u.Username).IsRequired();
            entity.Property(u => u.Email).IsRequired();
            entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
            // Will save the Role id in the Database because is a one-to-many relationship
            entity.OwnsOne(e => e.Name, n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(c => c.Name).HasColumnName("Name");
                n.Property(c => c.Surname).HasColumnName("Surname");
            });
        });
        
        builder.Entity<Supplier>(entity =>
        {
            entity.HasKey(m => m.Id);
            entity.Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(u => u.Username).IsRequired();
            entity.Property(u => u.Email).IsRequired();
            // entity.Property(u => u.RoleArea).IsRequired().HasConversion<string>(); // Less Efficiency, better readable database
            entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(20);
            entity.OwnsOne(e => e.Name, n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(c => c.Name).HasColumnName("Name");
                n.Property(c => c.Surname).HasColumnName("Surname");
            });
            
            // Will save the Role id in the Database because is a one-to-many relationship
            entity.HasOne(u => u.Role).WithMany();
            
        });

        builder.Entity<SupplierCredential>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(e => e.SupplierId).IsRequired();
            entity.Property(e => e.Argon2IdUserHash).IsRequired().HasMaxLength(50);

            entity.HasOne(w => w.Supplier).WithOne(p => p.SupplierCredential)
                .HasForeignKey<SupplierCredential>(wc => wc.SupplierId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supplier_credentials_supplier_id");
        });

        builder.Entity<AdministratorCredential>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
            entity.Property(e => e.AdminId).IsRequired();
            entity.Property(e => e.Argon2IdUserHash).IsRequired().HasMaxLength(50);

            entity.HasOne(a => a.Admin).WithOne(wc => wc.AdministratorCredential)
                .HasForeignKey<AdministratorCredential>(ac => ac.AdminId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_admin_credentials_admin_id");
        });
        
       
        builder.UseSnakeCaseNamingConvention();
    }
}

