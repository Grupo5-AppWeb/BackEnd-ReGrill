namespace ReGrill.API.Inventory.Domain.Model.Commands;

public record CreateAdminStockCommand(long UserId, string Ingredient, string Quantity, DateTime Date = default);