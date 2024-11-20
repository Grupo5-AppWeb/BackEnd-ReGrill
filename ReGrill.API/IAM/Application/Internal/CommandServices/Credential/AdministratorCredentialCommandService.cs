using ReGrill.API.IAM.Application.Internal.OutboundContext;
using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Credential;
using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Administration;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Application.Internal.CommandServices.Credential;

public class AdministratorCredentialCommandService(IUnitOfWork unitOfWork, IAdministratorCredentialRepository administratorCredentialRepository, IHashingService hashingService) : IAdministratorCredentialCommandService
{
    public async Task<bool> Handle(CreateUserCredentialCommand command)
    {
        try
        {
            var salt = hashingService.CreateSalt();

            var code = hashingService.HashCode(command.Argon2IdUserHash, salt);

            await administratorCredentialRepository.AddAsync(new AdministratorCredential(command.UserId, string.Concat(salt, code)));

            await unitOfWork.CompleteAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}