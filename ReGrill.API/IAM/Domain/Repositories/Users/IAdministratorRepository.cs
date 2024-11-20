
using ReGrill.API.IAM.Domain.Model.Aggregates.Management;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Domain.Repositories.Users;

public interface IAdministratorRepository : IBaseRepository<Administrator>
{
    Task<Administrator?> FindByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email);

    
    Task<int> FindIdByEmailAsync(string email);

}