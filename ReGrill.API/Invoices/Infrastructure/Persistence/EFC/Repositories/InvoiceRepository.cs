using ReGrill.API.Invoices.Domain.Model.Aggregates;
using ReGrill.API.Invoices.Domain.Repositories;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.Invoices.Infrastructure.Persistence.EFC.Repositories;

public class InvoiceRepository(AppDbContext context) : BaseRepository<Invoice>(context), IInvoiceRepository
{
    
}