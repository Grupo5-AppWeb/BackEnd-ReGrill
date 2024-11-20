using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Model.Queries;
using ReGrill.API.IAM.Domain.Repositories.Users;
using ReGrill.API.IAM.Domain.Services.Users.Supply;

namespace ReGrill.API.IAM.Application.Internal.QueryServices.Users;

public class SupplierQueryService(ISupplierRepository supplierRepository) : ISupplierQueryService
{
    public async Task<Supplier?> Handle(GetUserByIdQuery query)
    {
        return await supplierRepository.FindByIdAsync(query.Id);
    }

    public async Task<Supplier?> Handle(GetUserByEmailQuery query)
    {
        return await supplierRepository.FindByEmailAsync(query.Email);
    }

    public async Task<IEnumerable<Supplier>> Handle(GetAllUsersQuery query)
    {
        return await supplierRepository.ListAsync();

    }
}