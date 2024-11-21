using ReGrill.API.SupplierOrders.Domain.Model.Aggregates;
using ReGrill.API.SupplierOrders.Domain.Repositories;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.SupplierOrders.Infrastructure.Persistence.EFC.Repositories;

public class SupplierOrderRepository(AppDbContext context) : BaseRepository<SupplierOrder>(context), ISupplierOrderRepository{}