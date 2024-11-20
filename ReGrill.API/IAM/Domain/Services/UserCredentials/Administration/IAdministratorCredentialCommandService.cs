using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Credential;

namespace ReGrill.API.IAM.Domain.Services.UserCredentials.Administration;

public interface IAdministratorCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
    
}