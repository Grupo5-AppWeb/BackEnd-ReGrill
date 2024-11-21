namespace ReGrill.API.Invoices.Interfaces.REST.Resources;

public record CreateInvoiceResource(string InvoiceNumber, string Date, string Client, int Total, string Status);
