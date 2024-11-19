namespace ReGrill.API.Orders.Interfaces.REST.Resources;

public record UpdateOrderResource(int Id, int Cash, string Name, int Table, string Status, int Quantity);