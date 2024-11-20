using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.ValueObjects;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Domain.Repositories.Roles;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role?> FindByNameAsync(ERoles name);
    
    Task<bool> ExistsByNameAsync(ERoles name);
}