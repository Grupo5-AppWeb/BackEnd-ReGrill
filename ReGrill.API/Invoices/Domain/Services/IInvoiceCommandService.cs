using ReGrill.API.Invoices.Domain.Model.Commands;

namespace ReGrill.API.Invoices.Domain.Services;

public interface IInvoiceCommandService
{
    Task<Model.Aggregates.Invoice?> Handle(CreateInvoiceCommand command);

}