namespace ReGrill.API.Invoices.Interfaces.REST.Resources;

public record CreateInvoiceResource(string InvoiceNumber, DateTime Date, string Client, int Total, string Status);
