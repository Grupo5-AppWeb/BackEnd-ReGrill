using System.Text.Json.Serialization;
using ReGrill.API.Orders.Domain.Model.Aggregates;

namespace ReGrill.API.Orders.Domain.Model.Entities;

public class OrderItem
{
    public Guid OrderItemId { get; private set; } 
    public Guid OrderId { get; private set; } 
    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }
    
    [JsonIgnore]
    public Order? Order { get;  }

    public OrderItem(Guid orderId, string productName, int quantity, decimal price)
    {
        OrderItemId = Guid.NewGuid();
        OrderId = orderId;
        ProductName = productName;
        Quantity = quantity;
        Price = price;
    }
}