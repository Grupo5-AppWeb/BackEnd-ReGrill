using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Domain.Repositories.Credential;

public interface IAdministratorCredentialRepository: IBaseRepository<AdministratorCredential>
{
    Task<AdministratorCredential?> FindByAdministratorIdAsync(int administratorId);
}