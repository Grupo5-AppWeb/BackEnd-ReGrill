using ReGrill.API.Orders.Domain.Model.Commands;
using ReGrill.API.Orders.Interfaces.REST.Resources;

namespace ReGrill.API.Orders.Interfaces.REST.Transform;

public class UpdateOrderCommandFromResourceAssembler
{
    public static UpdateOrderCommand ToCommandFromResource(int id, UpdateOrderResource resource)
    {
        return new UpdateOrderCommand(id, resource.Cash, resource.Name, resource.Table, resource.Time,
            resource.Status, resource.Quantity);
    }
}