namespace ReGrill.API.Inventory.Interfaces.REST.Resources;

public record CreateAdminStockResource(long UserId, DateTime Date, string Ingredient, string Quantity);