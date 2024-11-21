using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;

namespace ReGrill.API.SupplierOrders.Domain.Model.Commands;

public record CreateSupplierOrderCommand(int SupplierId,
    string Status, List<Item> Items, DateTime OrderDate = default, DateTime DeliveryDate = default);