using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;
using ReGrill.API.SupplierOrders.Domain.Model.Queries;

namespace ReGrill.API.SupplierOrders.Domain.Services;

public interface ISupplierOrderQueryService
{
    Task<IEnumerable<SupplierOrder>> Handle(GetAllSupplierOrderQuery query);
    Task<SupplierOrder?> Handle(GetSupplierOrderByIdQuery query);
}