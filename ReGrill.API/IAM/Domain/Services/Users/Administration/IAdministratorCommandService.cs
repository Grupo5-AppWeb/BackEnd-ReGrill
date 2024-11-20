using ReGrill.API.IAM.Domain.Model.Commands;
using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Credential;
using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Manager;

namespace ReGrill.API.IAM.Domain.Services.Users.Administration;

public interface IAdministratorCommandService
{
    Task<int> Handle(SignUpAdministratorCommand command);

    Task<dynamic?> Handle(SignInCommand command);
}