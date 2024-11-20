using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Manager;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Administration;

namespace ReGrill.API.IAM.Interfaces.REST.Transform.Administration;

public class SignUpAdministratorCommandFromResourceAssembler
{
    public static SignUpAdministratorCommand ToCommandFromResource(SignUpAdministratorResource resource)
    {
        return new SignUpAdministratorCommand(resource.UserName, resource.Email, resource.Password,
             resource.PhoneNumber,
            resource.Name, resource.Surname);
    }
}