using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Inventory.Domain.Repositories;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ReGrill.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class AdminStockRepository(AppDbContext context) : BaseRepository<AdminStock>(context), IAdminStockRepository
{
    public async Task<IEnumerable<AdminStock>> FindByUserIdAsync(long userId)
    {
        return await Context.Set<AdminStock>().Where(a => a.UserId == userId).ToListAsync();
    }
}