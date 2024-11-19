using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Inventory.Domain.Model.Queries;
using ReGrill.API.Inventory.Domain.Repositories;
using ReGrill.API.Inventory.Domain.Services;

namespace ReGrill.API.Inventory.Application.Internal.QueryServices;

public class AdminStockQueryService(IAdminStockRepository adminStockRepository) : IAdminStockQueryService
{
    public Task<IEnumerable<AdminStock>> Handle(GetAllAdminStockQuery query)
    {
        return adminStockRepository.ListAsync();
    }
    
    public Task<IEnumerable<AdminStock>> Handle(GetAdminStockBySupplierQuery query)
    {
        return adminStockRepository.FindBySupplierAsync(query.Supplier.Supplier);
    }

    public async Task<AdminStock?> Handle(GetAdminStockByIdQuery query)
    {
        return await adminStockRepository.FindByIdAsync((int)query.StockId);
    }
}