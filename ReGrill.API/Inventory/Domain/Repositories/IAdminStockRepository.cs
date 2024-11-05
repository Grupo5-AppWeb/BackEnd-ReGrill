using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.Inventory.Domain.Repositories;

public interface IAdminStockRepository : IBaseRepository<AdminStock>
{
    Task<IEnumerable<AdminStock>> FindByUserIdAsync(long userId);
}