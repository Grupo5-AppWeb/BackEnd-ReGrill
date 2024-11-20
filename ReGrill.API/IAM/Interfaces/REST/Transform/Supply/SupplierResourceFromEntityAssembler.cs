using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Supply;

namespace ReGrill.API.IAM.Interfaces.REST.Transform.Supply;

public class SupplierResourceFromEntityAssembler
{
    public static SupplierResource ToResourceFromEntity(Supplier entity)
    {
        return new SupplierResource(entity.Username, entity.Email, 
            entity.PhoneNumber,
            entity.Name.Name, entity.Name.Surname);
    }
}