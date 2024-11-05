using ReGrill.API.Orders.Domain.Model.Entities;

namespace ReGrill.API.Orders.Interfaces.REST.Resources;

public record OrderResource(Guid OrderId, DateTime OrderDate, List<OrderItem> OrderItems);