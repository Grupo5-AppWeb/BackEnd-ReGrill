using ReGrill.API.Profile.Domain.Model.Commands;
using ReGrill.API.Profile.Interfaces.Resources;

namespace ReGrill.API.Profile.Interfaces.Transform;

public class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(
            resource.Dni,
            resource.FirstName,
            resource.LastName,
            resource.Email,
            resource.Password
        );
    }

}