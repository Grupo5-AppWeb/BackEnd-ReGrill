using ReGrill.API.Invoices.Domain.Model.Commands;

namespace ReGrill.API.Invoices.Domain.Model.Aggregates;

public class Invoice
{
    public int Id { get; private set; }
    public string InvoiceNumber { get; private set; }
    public DateTime Date { get; private set; }
    public string Client { get; private set; }
    public int Total { get; private set; }
    public string Status { get; private set; }
    
    public Invoice()
    {

    }
    public Invoice(CreateInvoiceCommand command)
    {
        InvoiceNumber = command.InvoiceNumber;
        Date = command.Date;
        Client = command.Client;
        Total = command.Total;
        Status = command.Status;
       
    }
}

