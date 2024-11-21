using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;
using ReGrill.API.SupplierOrders.Domain.Model.Commands;

namespace ReGrill.API.SupplierOrders.Domain.Services;

public interface ISupplierOrderCommandService
{
    Task<SupplierOrder?> Handle(CreateSupplierOrderCommand command);
}