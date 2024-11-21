using ReGrill.API.Invoices.Domain.Model.Commands;
using ReGrill.API.Invoices.Interfaces.REST.Resources;
using ReGrill.API.Orders.Domain.Model.Commands;
using ReGrill.API.Orders.Interfaces.REST.Resources;

namespace ReGrill.API.Invoices.Interfaces.REST.Transform;

public static class CreateInvoiceCommandFromResourceAssembler
{

    public static CreateInvoiceCommand ToCommandFromResource(CreateInvoiceResource resource)
    {
        return new CreateInvoiceCommand(resource.InvoiceNumber, resource.Client, resource.Total, resource.Status,
            resource.Date);
    }
}