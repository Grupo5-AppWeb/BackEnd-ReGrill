using Microsoft.EntityFrameworkCore;
using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;
using ReGrill.API.SupplierOrders.Domain.Model.Queries;
using ReGrill.API.SupplierOrders.Domain.Repositories;
using ReGrill.API.SupplierOrders.Domain.Services;

namespace ReGrill.API.SupplierOrders.Application.Internal.QueryServices;

public class SupplierOrderQueryService(ISupplierOrderRepository supplierOrderRepository): ISupplierOrderQueryService
{
    public async Task<IEnumerable<SupplierOrder>> Handle(GetAllSupplierOrderQuery query)
    {
        return await supplierOrderRepository
            .GetAll()
            .Include(r => r.Items)
            .ToListAsync();
    }
    
    public async Task<SupplierOrder?> Handle(GetSupplierOrderByIdQuery query)
    {
        return await supplierOrderRepository.FindByIdAsync((int)query.SupplierOrderId);
    }
}