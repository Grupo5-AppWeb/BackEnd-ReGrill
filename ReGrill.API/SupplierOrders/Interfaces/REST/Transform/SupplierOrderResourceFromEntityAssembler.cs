using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;
using ReGrill.API.SupplierOrders.Interfaces.REST.Resources;

namespace ReGrill.API.SupplierOrders.Interfaces.REST.Transform;

public static class SupplierOrderResourceFromEntityAssembler
{
    public static SupplierOrderResource ToResourceFromEntity(SupplierOrder supplierOrder)
    {
        var items = supplierOrder.Items.Select(i => new ItemsResource
            (i.Id, i.Name, i.Quantity, i.Price)).ToList();
        return new SupplierOrderResource(supplierOrder.Id, supplierOrder.SupplierId, 
            supplierOrder.OrderDate.ToString("yyyy-MM-dd"),
            supplierOrder.DeliveryDate.ToString("yyyy-MM-dd"), supplierOrder.Status, items);
    }
}