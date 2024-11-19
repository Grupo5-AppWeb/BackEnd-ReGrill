namespace ReGrill.API.Orders.Domain.Model.Commands;

public record CreateOrderCommand(int Cash, string Name, int Table, string Status, int Quantity, DateTime Time = default);