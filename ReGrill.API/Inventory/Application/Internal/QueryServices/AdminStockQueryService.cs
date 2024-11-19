using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Inventory.Domain.Model.Queries;
using ReGrill.API.Inventory.Domain.Repositories;
using ReGrill.API.Inventory.Domain.Services;

namespace ReGrill.API.Inventory.Application.Internal.QueryServices;

public class AdminStockQueryService(IAdminStockRepository adminStockRepository) : IAdminStockQueryService
{
    public Task<IEnumerable<AdminStock>> Handle(GetAdminStockByUserIdQuery query)
    {
        return adminStockRepository.FindByUserIdAsync(query.UserId.Id);
    }

    public async Task<AdminStock?> Handle(GetAdminStockByIdQuery query)
    {
        var guidFromInt = new Guid(query.StockId.ToString("D").PadLeft(32, '0'));
        return await adminStockRepository.FindByIdAsync(guidFromInt);
    }
}