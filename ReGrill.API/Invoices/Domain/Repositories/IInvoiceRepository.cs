using ReGrill.API.Invoices.Domain.Model.Aggregates;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.Invoices.Domain.Repositories;

public interface IInvoiceRepository: IBaseRepository<Invoice>
{
    
}