using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.Queries;
using ReGrill.API.IAM.Domain.Repositories.Roles;
using ReGrill.API.IAM.Domain.Services.Roles;

namespace ReGrill.API.IAM.Application.Internal.QueryServices.Roles;

public class RoleQueryService(IRoleRepository roleRepository) : IRoleQueryService
{
    public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery query)
    {
        return await roleRepository.ListAsync();
    }

    public async Task<Role?> Handle(GetRoleByNameQuery query)
    {
        return await roleRepository.FindByNameAsync(query.Name);
    }
}