namespace ReGrill.API.SupplierOrders.Domain.Model.Aggregates;

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Quantity { get; set; }
    public string Price { get; set; }
    public int SupplierOrderId { get; set; }
    public Item() {}
}