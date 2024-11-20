using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Credential;

namespace ReGrill.API.IAM.Domain.Services.UserCredentials.Supplier;

public interface ISupplierCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
}