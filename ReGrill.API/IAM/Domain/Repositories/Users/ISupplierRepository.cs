using ReGrill.API.Shared.Domain.Repositories;
using Supplier = ReGrill.API.IAM.Domain.Model.Aggregates.Supplier.Supplier;

namespace ReGrill.API.IAM.Domain.Repositories.Users;

public interface ISupplierRepository : IBaseRepository<Supplier>
{
    Task<Supplier?> FindByEmailAsync(string email);

    Task<bool> ExistByEmailAsync(string email);
}