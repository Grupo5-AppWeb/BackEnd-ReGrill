using ReGrill.API.IAM.Domain.Model.Aggregates.Management;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Administration;

namespace ReGrill.API.IAM.Interfaces.REST.Transform.Administration;

public static class AdministratorResourceFromEntityAssembler
{
    public static AdministratorResource ToResourceFromEntity(Administrator entity)
    {
        return new AdministratorResource(entity.Id, entity.Username, entity.Email, entity.Name.Name, entity.PhoneNumber,
             entity.Name
                .Surname);
    }
}