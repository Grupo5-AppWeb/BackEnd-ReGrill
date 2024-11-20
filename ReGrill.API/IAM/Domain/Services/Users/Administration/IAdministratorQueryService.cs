using ReGrill.API.IAM.Domain.Model.Aggregates.Management;
using ReGrill.API.IAM.Domain.Model.Queries;

namespace ReGrill.API.IAM.Domain.Services.Users.Administration;

public interface IAdministratorQueryService
{
    Task<Administrator?> Handle(GetUserByIdQuery query);

    Task<Administrator?> Handle(GetUserByEmailQuery query);

    Task<IEnumerable<Administrator>> Handle(GetAllUsersQuery query);

    Task<int> Handle(GetUserIdByEmailQuery query);
}