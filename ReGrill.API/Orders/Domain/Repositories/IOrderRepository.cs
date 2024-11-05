using Regrill.API.Orders.Domain.Model.Aggregates;
using ReGrill.API.Shared.Domain.Repositories;

namespace Regrill.API.Orders.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    
}