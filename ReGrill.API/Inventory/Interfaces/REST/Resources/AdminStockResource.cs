using ReGrill.API.Inventory.Domain.Model.ValueObjects;

namespace ReGrill.API.Inventory.Interfaces.REST.Resources;

public record AdminStockResource(
    long Id,
    string Date,
    string Ingredient,
    string Quantity,
    SupplierName Supplier
);