using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Model.Queries;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Supplier;

namespace ReGrill.API.IAM.Application.Internal.QueryServices.Credential;

public class SupplierCredentialQueryService(ISupplierCredentialRepository supplierCredentialRepository) : ISupplierCredentialQueryService
{
    public async Task<SupplierCredential?> Handle(GetUserCredentialByUserIdQuery query)
    {
        return await supplierCredentialRepository.FindBySupplierIdAsync(query.UserId);
    }
}