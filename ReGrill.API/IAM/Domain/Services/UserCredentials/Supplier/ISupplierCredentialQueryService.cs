using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Model.Queries;

namespace ReGrill.API.IAM.Domain.Services.UserCredentials.Supplier;

public interface ISupplierCredentialQueryService
{
    Task<SupplierCredential?> Handle(GetUserCredentialByUserIdQuery query);
}