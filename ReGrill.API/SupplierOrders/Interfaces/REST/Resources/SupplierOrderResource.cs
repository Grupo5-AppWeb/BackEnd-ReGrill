namespace ReGrill.API.SupplierOrders.Interfaces.REST.Resources;

public record SupplierOrderResource (long Id, long SupplierId, string OrderDate, string DeliveryDate, string Status, 
    List<ItemsResource> Items) ;