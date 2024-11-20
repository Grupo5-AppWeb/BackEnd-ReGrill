namespace ReGrill.API.Orders.Interfaces.REST.Resources;

public record UpdateOrderResource(int Cash, string Name, int Table, DateTime Time, string Status, int Quantity);