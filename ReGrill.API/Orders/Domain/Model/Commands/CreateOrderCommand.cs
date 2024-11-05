using ReGrill.API.Orders.Domain.Model.Entities;

namespace Regrill.API.Orders.Domain.Model.Commands;

public record CreateOrderCommand(List<OrderItem> OrderItems);