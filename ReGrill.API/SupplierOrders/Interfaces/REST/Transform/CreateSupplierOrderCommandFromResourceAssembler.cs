using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;
using ReGrill.API.SupplierOrders.Domain.Model.Commands;
using ReGrill.API.SupplierOrders.Interfaces.REST.Resources;

namespace ReGrill.API.SupplierOrders.Interfaces.REST.Transform;

public static class CreateSupplierOrderCommandFromResourceAssembler
{
    public static CreateSupplierOrderCommand ToCommandFromResource(CreateSupplierOrderResource resource)
    {
        var items = resource.Items.Select(i => new Item
        {
            Name = i.Name,
            Quantity = i.Quantity,
            Price = i.Price
        }).ToList();
        return new CreateSupplierOrderCommand(resource.SupplierId, resource.Status, items, resource.OrderDate,
            resource.DeliveryDate);
    }
}