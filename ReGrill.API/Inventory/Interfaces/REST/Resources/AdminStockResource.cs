namespace ReGrill.API.Inventory.Interfaces.REST.Resources;

public record AdminStockResource(
    long Id,
    string Date,
    string Ingredient,
    string Quantity,
    string Supplier
);