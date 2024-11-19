using ReGrill.API.Orders.Domain.Model.Entities;

namespace ReGrill.API.Orders.Interfaces.REST.Resources;

public record CreateOrderResource(List<OrderItem> OrderItems);

    
