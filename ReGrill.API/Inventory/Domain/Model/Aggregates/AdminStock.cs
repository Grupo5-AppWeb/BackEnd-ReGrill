using ReGrill.API.Inventory.Domain.Model.Commands;
using ReGrill.API.Inventory.Domain.Model.ValueObjects;

namespace ReGrill.API.Inventory.Domain.Model.Aggregates;

public partial class AdminStock
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Ingredient { get; private set; }
    public string Quantity { get; private set; }
    
    public long UserId { get; private set; }
    
    public UserId UserIdValue { get; private set; }
    

    public AdminStock()
    {
    }

    public AdminStock(CreateAdminStockCommand command)
    {
        UserIdValue = new UserId(command.UserId);
        
        UserId = command.UserId;
        Date = command.Date;
        Ingredient = command.Ingredient;
        Quantity = command.Quantity;
    }
}