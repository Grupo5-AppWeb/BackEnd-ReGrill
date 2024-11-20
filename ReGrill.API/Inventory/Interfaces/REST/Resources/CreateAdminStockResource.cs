namespace ReGrill.API.Inventory.Interfaces.REST.Resources;

public record CreateAdminStockResource(DateTime Date, string Ingredient, string Quantity, string Supplier);