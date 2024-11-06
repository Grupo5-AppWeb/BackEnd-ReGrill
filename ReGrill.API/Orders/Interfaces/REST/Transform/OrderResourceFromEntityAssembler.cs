using ReGrill.API.Orders.Domain.Model.Aggregates;
using ReGrill.API.Orders.Interfaces.REST.Resources;

namespace ReGrill.API.Orders.Interfaces.REST.Transform;

public static class OrderResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles an <see cref="OrderResource"/> from an <see cref="Order"/>.
    /// </summary>
    /// <param name="entity">The <see cref="Order"/> to assemble from.</param>
    /// <returns>The assembled <see cref="OrderResource"/>.</returns>
    public static OrderResource ToResourceFromEntity(Order entity) =>
        new OrderResource(entity.OrderId, entity.OrderDate, entity.OrderItems);
}