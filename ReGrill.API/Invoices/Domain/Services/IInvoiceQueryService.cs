using ReGrill.API.Invoices.Domain.Model.Aggregates;
using ReGrill.API.Invoices.Domain.Model.Queries;

namespace ReGrill.API.Invoices.Domain.Services;

public interface IInvoiceQueryService

{
    Task<IEnumerable<Invoice>> Handle(GetAllInvoicesQuery query);
    
    Task<Invoice?> Handle(GetInvoicesByIdQuery query);
}