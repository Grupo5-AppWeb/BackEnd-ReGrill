using ReGrill.API.Orders.Domain.Model.Aggregates;
using ReGrill.API.Orders.Domain.Model.Commands;

namespace ReGrill.API.Orders.Domain.Services;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);

    Task Handle(DeleteOrderCommand command);

    Task<Order?> Handle(UpdateOrderCommand command);
}