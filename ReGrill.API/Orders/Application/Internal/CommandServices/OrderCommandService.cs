using ReGrill.API.Orders.Domain.Model.Aggregates;
using ReGrill.API.Orders.Domain.Model.Commands;
using ReGrill.API.Orders.Domain.Repositories;
using ReGrill.API.Orders.Domain.Services;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.Orders.Application.Internal.CommandServices;

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