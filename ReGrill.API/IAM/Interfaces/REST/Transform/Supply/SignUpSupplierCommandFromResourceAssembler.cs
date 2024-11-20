using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Supplier;
using ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Supply;

namespace ReGrill.API.IAM.Interfaces.REST.Transform.Supply;

public class SignUpSupplierCommandFromResourceAssembler
{
    public static SignUpSupplierCommand ToCommandFromResource(SignUpSupplierResource resource)
    {
        return new(resource.UserName, resource.Email, resource.Password, resource.PhoneNumber, resource.Surname,
            resource.Name);
    }
}