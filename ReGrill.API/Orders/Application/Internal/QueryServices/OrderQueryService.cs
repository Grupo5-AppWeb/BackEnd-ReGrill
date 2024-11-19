using ReGrill.API.Orders.Domain.Model.Aggregates;
using ReGrill.API.Orders.Domain.Model.Queries;
using ReGrill.API.Orders.Domain.Repositories;
using ReGrill.API.Orders.Domain.Services;

namespace ReGrill.API.Orders.Application.Internal.QueryServices;

public class OrderQueryService(IOrderRepository orderRepository): IOrderQueryService
{
    public async Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query)
    {
        return await orderRepository.ListAsync();
    }
    
    public async Task<Order?> Handle(GetOrdersByIdQuery query)
    {
        return await orderRepository.FindByIdAsync((int)query.OrderId);
    }
}