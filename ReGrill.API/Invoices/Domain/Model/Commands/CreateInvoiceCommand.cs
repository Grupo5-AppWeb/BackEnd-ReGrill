namespace ReGrill.API.Invoices.Domain.Model.Commands;

public record CreateInvoiceCommand(string InvoiceNumber, string Date, string Client, int Total, string Status);
