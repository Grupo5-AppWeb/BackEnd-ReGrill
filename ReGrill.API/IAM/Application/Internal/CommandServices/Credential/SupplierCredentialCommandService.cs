using ReGrill.API.IAM.Application.Internal.OutboundContext;
using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Credential;
using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.IAM.Domain.Services.UserCredentials.Supplier;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Application.Internal.CommandServices.Credential;

public class SupplierCredentialCommandService(IUnitOfWork unitOfWork, ISupplierCredentialRepository supplierCredentialRepository, IHashingService hashingService) : ISupplierCredentialCommandService
{
    public async Task<bool> Handle(CreateUserCredentialCommand command)
    {
        try
        {
            var salt = hashingService.CreateSalt();

            var code = hashingService.HashCode(command.Argon2IdUserHash, salt);

            await supplierCredentialRepository.AddAsync(new SupplierCredential(command.UserId, string.Concat(salt, code)));

            await unitOfWork.CompleteAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}