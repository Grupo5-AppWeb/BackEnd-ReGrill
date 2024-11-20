using ReGrill.API.Inventory.Domain.Model.ValueObjects;
using ReGrill.API.Inventory.Domain.Model.Aggregates;
using ReGrill.API.Inventory.Interfaces.REST.Resources;

namespace ReGrill.API.Inventory.Interfaces.REST.Transform;

public class AdminStockResourceFromEntityAssembler
{
    public static AdminStockResource ToResourceFromEntity(AdminStock adminStock)
    {
        return new AdminStockResource(adminStock.Id, adminStock.Date.ToString("yyyy-MM-dd"), adminStock.Ingredient, adminStock.Quantity, new SupplierName(adminStock.Supplier));
    }
}