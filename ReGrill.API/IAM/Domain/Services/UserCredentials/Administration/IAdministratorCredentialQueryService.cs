using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Model.Queries;

namespace ReGrill.API.IAM.Domain.Services.UserCredentials.Administration;

public interface IAdministratorCredentialQueryService
{
    Task<AdministratorCredential?> Handle(GetUserCredentialByUserIdQuery query);
}