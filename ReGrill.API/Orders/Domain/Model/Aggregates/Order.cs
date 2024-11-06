using ReGrill.API.Orders.Domain.Model.Commands;
using ReGrill.API.Orders.Domain.Model.Entities;

namespace ReGrill.API.Orders.Domain.Model.Aggregates;

public class Order
{
    public Guid OrderId { get; private set; }
    public DateTime OrderDate { get; private set; }
    public List<OrderItem> OrderItems { get; private set; }

    public Order()
    {
        
    }
    public Order(CreateOrderCommand command)
    {
        OrderId = Guid.NewGuid();
        OrderDate = DateTime.UtcNow;
        OrderItems = command.OrderItems;
    }
}