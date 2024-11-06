using ReGrill.API.Orders.Domain.Model.Entities;

namespace ReGrill.API.Orders.Domain.Model.Commands;

public record CreateOrderCommand(List<OrderItem> OrderItems);