using ReGrill.API.Orders.Domain.Model.Commands;
using ReGrill.API.Orders.Interfaces.REST.Resources;

namespace ReGrill.API.Orders.Interfaces.REST.Transform;

public static class DeleteOrderCommandFromResourceAssembler
{
    public static DeleteOrderCommand ToCommandFromResource(DeleteOrderResource resource)
    {
        return new DeleteOrderCommand(resource.Id);
    }
}