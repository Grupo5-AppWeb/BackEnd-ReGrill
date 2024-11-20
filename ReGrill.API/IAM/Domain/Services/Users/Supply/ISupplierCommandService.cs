using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Model.Commands;
using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Supplier;

namespace ReGrill.API.IAM.Domain.Services.Users.Supply;
public interface ISupplierCommandService
{
    Task<Supplier> Handle(SignUpSupplierCommand command);

    Task<dynamic?> Handle(SignInCommand command);
}