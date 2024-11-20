using ReGrill.API.IAM.Domain.Model.Entities.User;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication;

namespace ReGrill.API.IAM.Interfaces.REST.Transform.Anthentication;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    }
}