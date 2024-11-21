using ReGrill.API.Invoices.Domain.Model.Aggregates;
using ReGrill.API.Invoices.Domain.Model.Queries;
using ReGrill.API.Invoices.Domain.Repositories;
using ReGrill.API.Invoices.Domain.Services;

namespace ReGrill.API.Invoices.Application.Internal.QueryServices;

public class InvoiceQueryService(IInvoiceRepository invoiceRepository) : IInvoiceQueryService
{
    public async Task<IEnumerable<Invoice>> Handle(GetAllInvoicesQuery query)
    {
        return await invoiceRepository.ListAsync();
    }
    public async Task<Invoice?> Handle(GetInvoicesByIdQuery query)
    {
        return await invoiceRepository.FindByIdAsync((int)query.InvoiceId);
    }
}