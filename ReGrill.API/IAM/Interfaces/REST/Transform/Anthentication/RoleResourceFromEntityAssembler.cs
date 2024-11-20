using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Interfaces.REST.Resources.Roles;

namespace ReGrill.API.IAM.Interfaces.REST.Transform.Anthentication;

public class RoleResourceFromEntityAssembler
{
    public static RoleResource ToResourceFromEntity(Role entity)
    {
        return new RoleResource(entity.Id, entity.GetStringName());
    }
}