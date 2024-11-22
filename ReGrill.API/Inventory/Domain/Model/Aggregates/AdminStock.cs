using ReGrill.API.Inventory.Domain.Model.Commands;

namespace ReGrill.API.Inventory.Domain.Model.Aggregates;

public class AdminStock
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Ingredient { get; private set; }
    public string Quantity { get; private set; }

    public string Supplier { get; private set; }

    public AdminStock()
    {
    }

    public AdminStock(CreateAdminStockCommand command)
    {
        Supplier = command.Supplier;
        Date = command.Date;
        Ingredient = command.Ingredient;
        Quantity = command.Quantity;
    }
}