namespace ReGrill.API.Invoices.Interfaces.REST.Resources;

public record InvoiceResource(long Id, string InvoiceNumber, string Date, string Client, int Total, string Status);
