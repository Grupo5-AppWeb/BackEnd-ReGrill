namespace ReGrill.API.SupplierOrders.Interfaces.REST.Resources;

public record CreateSupplierOrderResource (int SupplierId, DateTime OrderDate, DateTime DeliveryDate, string Status, 
    List<ItemsResource> Items) ;