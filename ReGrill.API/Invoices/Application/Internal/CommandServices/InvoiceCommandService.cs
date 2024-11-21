using ReGrill.API.Invoices.Domain.Model.Aggregates;
using ReGrill.API.Invoices.Domain.Model.Commands;
using ReGrill.API.Invoices.Domain.Repositories;
using ReGrill.API.Invoices.Domain.Services;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.Invoices.Application.Internal.CommandServices;

public class InvoiceCommandService(IInvoiceRepository orderRepository, IUnitOfWork unitOfWork) : IInvoiceCommandService
{
    public async Task<Invoice?> Handle(CreateInvoiceCommand command)
    {

        var order = new Invoice(command);
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