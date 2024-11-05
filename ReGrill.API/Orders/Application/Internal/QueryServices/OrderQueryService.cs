using Regrill.API.Orders.Domain.Model.Aggregates;
using Regrill.API.Orders.Domain.Model.Queries;
using Regrill.API.Orders.Domain.Repositories;
using Regrill.API.Orders.Domain.Services;

namespace Regrill.API.Orders.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository): IOrderQueryService
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }
    
    public async Task<Order> Handle(GetOrderByIdQuery query)
    {
        return await orderRepository.FindByIdAsync(query.OrderId);
    }
}