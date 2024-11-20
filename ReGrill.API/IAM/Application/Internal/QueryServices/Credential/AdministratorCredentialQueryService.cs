using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Model.Queries;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Administration;

namespace ReGrill.API.IAM.Application.Internal.QueryServices.Credential;

internal class AdministratorCredentialQueryService(IAdministratorCredentialRepository administratorCredentialRepository) : IAdministratorCredentialQueryService
{
    public async Task<AdministratorCredential?> Handle(GetUserCredentialByUserIdQuery query)
    {
        return await administratorCredentialRepository.FindByAdministratorIdAsync(query.UserId);
    }
}