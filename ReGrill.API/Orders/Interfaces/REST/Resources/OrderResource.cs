namespace ReGrill.API.Orders.Interfaces.REST.Resources;

public record OrderResource(
    long Id,
    int Cash,
    string Name,
    int Table,
    string Time,
    string Status,
    int Quantity);