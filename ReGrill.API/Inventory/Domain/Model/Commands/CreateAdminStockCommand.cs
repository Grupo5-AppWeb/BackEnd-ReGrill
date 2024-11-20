namespace ReGrill.API.Inventory.Domain.Model.Commands;

public record CreateAdminStockCommand(string Ingredient, string Quantity, string Supplier, DateTime Date = default);