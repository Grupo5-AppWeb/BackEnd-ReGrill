using Regrill.API.Orders.Domain.Model.Aggregates;
using Regrill.API.Orders.Domain.Model.Commands;
using Regrill.API.Orders.Domain.Repositories;
using Regrill.API.Orders.Domain.Services;
using Regrill.API.Shared.Domain.Repositories;

namespace Regrill.API.Orders.Application.Internal.CommandServices;

public class OrderCommandService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : IOrderCommandService
{
    public async Task<Order?> Handle(CreateOrderCommand command)
    {
        
        var order = new Order(command);
        try
        {
            await orderRepository.AddAsync(order);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return order;
    }
}