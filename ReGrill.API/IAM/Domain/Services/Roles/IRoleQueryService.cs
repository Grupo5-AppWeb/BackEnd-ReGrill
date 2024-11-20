using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.Queries;

namespace ReGrill.API.IAM.Domain.Services.Roles;

public interface IRoleQueryService
{
    Task<IEnumerable<Role>> Handle(GetAllRolesQuery query);

    Task<Role?> Handle(GetRoleByNameQuery query);
}