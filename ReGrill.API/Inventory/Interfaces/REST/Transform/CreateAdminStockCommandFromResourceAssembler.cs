using ReGrill.API.Inventory.Domain.Model.Commands;
using ReGrill.API.Inventory.Interfaces.REST.Resources;

namespace ReGrill.API.Inventory.Interfaces.REST.Transform;

public class CreateAdminStockCommandFromResourceAssembler
{
    public static CreateAdminStockCommand ToCommandFromResource(CreateAdminStockResource resource)
    {
        return new CreateAdminStockCommand(resource.UserId, resource.Ingredient, resource.Quantity, resource.Date);
    }
}