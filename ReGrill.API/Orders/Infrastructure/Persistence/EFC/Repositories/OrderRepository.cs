using ReGrill.API.Orders.Domain.Model.Aggregates;
using ReGrill.API.Orders.Domain.Repositories;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.Orders.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository(AppDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    
}