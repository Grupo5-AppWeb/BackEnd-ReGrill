using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Model.Entities.User;
using ReGrill.API.SupplierOrders.Domain.Model.Commands;

namespace ReGrill.API.SupplierOrders.Domain.Model.Aggregates;

public class SupplierOrder
{
    public int Id { get; private set; }
    public int SupplierId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public DateTime DeliveryDate { get; private set; }
    public string Status { get; private set; }
    public List<Item> Items { get; private set; }
    
    public SupplierOrder()
    {
        Items = new List<Item>();
    }

    public SupplierOrder(CreateSupplierOrderCommand command)
    {
        SupplierId = command.SupplierId;
        OrderDate = command.OrderDate;
        DeliveryDate = command.DeliveryDate;
        Status = command.Status;
        Items = command.Items;
    }
}