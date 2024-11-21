using ReGrill.API.Invoices.Domain.Model.Aggregates;
using ReGrill.API.Invoices.Interfaces.REST.Resources;

namespace ReGrill.API.Invoices.Interfaces.REST.Transform;

public static class InvoiceResourceFromEntityAssembler
{
  
    public static InvoiceResource ToResourceFromEntity(Invoice invoice)
    {
        return new InvoiceResource(invoice.Id, invoice.InvoiceNumber, invoice.Date, invoice.Client, invoice.Total,
            invoice.Status);
    }
        
}