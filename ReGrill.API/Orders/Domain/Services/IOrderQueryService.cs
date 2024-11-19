using ReGrill.API.Orders.Domain.Model.Aggregates;
using ReGrill.API.Orders.Domain.Model.Queries;

namespace ReGrill.API.Orders.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    Task<Order> Handle(GetOrderByIdQuery query);
}