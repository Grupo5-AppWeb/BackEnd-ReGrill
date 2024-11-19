using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Inventory.Domain.Model.Queries;

namespace ReGrill.API.Inventory.Domain.Services;

public interface IAdminStockQueryService
{
    Task<IEnumerable<AdminStock>> Handle(GetAllAdminStockQuery query);
    Task<IEnumerable<AdminStock>> Handle(GetAdminStockBySupplierQuery query);
    Task<AdminStock?> Handle(GetAdminStockByIdQuery query);
}