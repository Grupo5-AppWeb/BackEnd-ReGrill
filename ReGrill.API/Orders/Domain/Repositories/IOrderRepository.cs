using ReGrill.API.Shared.Domain.Repositories;
using ReGrill.API.Orders.Domain.Model.Aggregates;

namespace ReGrill.API.Orders.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    
}