using ReGrill.API.Inventory.Domain.Model.Commands;
using ReGrill.API.Inventory.Domain.Model.ValueObjects;

namespace ReGrill.API.Inventory.Domain.Model.Aggregates;

public partial class AdminStock
{
    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public string Ingredient { get; private set; }
    public string Quantity { get; private set; }
    
    public string Supplier { get; private set; }
    
    public SupplierName SupplierNameValue { get; private set; }  
    
    public AdminStock()
    {
    }

    public AdminStock(CreateAdminStockCommand command)
    {
        SupplierNameValue = new SupplierName(command.Supplier);
        
        Supplier = command.Supplier;
        Date = command.Date;
        Ingredient = command.Ingredient;
        Quantity = command.Quantity;
    }
}