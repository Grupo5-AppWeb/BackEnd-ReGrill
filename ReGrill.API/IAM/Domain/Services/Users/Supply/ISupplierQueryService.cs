using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Model.Queries;

namespace ReGrill.API.IAM.Domain.Services.Users.Supply;

public interface ISupplierQueryService
{
    Task<Supplier?> Handle(GetUserByIdQuery query);

    Task<Supplier?> Handle(GetUserByEmailQuery query);

    Task<IEnumerable<Supplier>> Handle(GetAllUsersQuery query);
}