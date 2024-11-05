using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
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
        builder.Entity<AdminStock>().Property(a => a.UserId).HasColumnName("UserId").IsRequired();
        builder.Entity<AdminStock>().Ignore(a => a.UserIdValue);
        
        builder.UseSnakeCaseNamingConvention();
    }
}

