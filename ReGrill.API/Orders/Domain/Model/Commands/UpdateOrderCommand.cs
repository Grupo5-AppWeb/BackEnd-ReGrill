namespace ReGrill.API.Orders.Domain.Model.Commands;

public record UpdateOrderCommand(int Id, int Cash, string Name, int Table, string Status, int Quantity);