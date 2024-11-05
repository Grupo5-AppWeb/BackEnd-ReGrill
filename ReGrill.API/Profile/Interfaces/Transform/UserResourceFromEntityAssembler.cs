using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Profile.Interfaces.Resources;

namespace ReGrill.API.Profile.Interfaces.Transform;

public class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User user)
    {
        return new UserResource(
            user.Id,
            user.Dni,
            user.FirstName,
            user.LastName,
            user.Email,
            user.Password
        );
    }
}