using ReGrill.API.Shared.Domain.Repositories;
using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;
using ReGrill.API.SupplierOrders.Domain.Model.Commands;
using ReGrill.API.SupplierOrders.Domain.Repositories;
using ReGrill.API.SupplierOrders.Domain.Services;
using ReGrill.API.SupplierOrders.Domain.Repositories;

namespace ReGrill.API.SupplierOrders.Application.Internal.CommandServices;

public class SupplierOrderCommandService(
    ISupplierOrderRepository supplierOrderRepository,
    IUnitOfWork unitOfWork) : ISupplierOrderCommandService
{
    public async Task<SupplierOrder?> Handle(CreateSupplierOrderCommand command)
    {
        var supplierOrder = new SupplierOrder(command);
        try
        {
            await supplierOrderRepository.AddAsync(supplierOrder);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        return supplierOrder;
    }
}