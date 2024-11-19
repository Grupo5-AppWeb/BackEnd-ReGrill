using ReGrill.API.Orders.Domain.Model.Commands;
using ReGrill.API.Orders.Interfaces.REST.Resources;

namespace ReGrill.API.Orders.Interfaces.REST.Transform;

public static class CreateOrderCommandFromResourceAssembler
{
    /// <summary>
    /// Assembles a <see cref="CreateOrderCommand"/> from a <see cref="CreateOrderResource"/>.
    /// </summary>
    /// <param name="resource">The <see cref="CreateOrderResource"/> to assemble from.</param>
    /// <returns>The assembled <see cref="CreateOrderCommand"/>.</returns>
    public static CreateOrderCommand ToCommandFromResource(CreateOrderResource resource) =>
        new CreateOrderCommand(resource.OrderItems);
}