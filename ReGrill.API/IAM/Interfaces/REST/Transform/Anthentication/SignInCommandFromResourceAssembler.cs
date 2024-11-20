using ReGrill.API.IAM.Domain.Model.Commands;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication;

namespace ReGrill.API.IAM.Interfaces.REST.Transform.Anthentication;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}