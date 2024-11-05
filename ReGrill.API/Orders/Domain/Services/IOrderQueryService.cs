using Regrill.API.Orders.Domain.Model.Aggregates;
using Regrill.API.Orders.Domain.Model.Queries;

namespace Regrill.API.Orders.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    Task<Order> Handle(GetOrderByIdQuery query);
}