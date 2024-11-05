using Regrill.API.Orders.Domain.Model.Aggregates;
using Regrill.API.Orders.Domain.Model.Commands;

namespace Regrill.API.Orders.Domain.Services;

public interface IOrderCommandService
{
    Task<Order?> Handle(CreateOrderCommand command);
}