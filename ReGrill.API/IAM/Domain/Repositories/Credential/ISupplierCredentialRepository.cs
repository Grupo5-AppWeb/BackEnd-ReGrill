using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Domain.Repositories.Credential;

public interface ISupplierCredentialRepository: IBaseRepository<SupplierCredential>
{
    Task<SupplierCredential?> FindBySupplierIdAsync(int supplierId);
}