namespace ReGrill.API.Invoices.Domain.Model.Commands;

public record CreateInvoiceCommand(string InvoiceNumber, string Client, int Total, string Status, DateTime Date = default);
