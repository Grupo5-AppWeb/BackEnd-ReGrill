using ReGrill.API.IAM.Domain.Model.Commands.Role;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.ValueObjects;
using ReGrill.API.IAM.Domain.Repositories.Roles;
using ReGrill.API.IAM.Domain.Services.Roles;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Application.Internal.CommandServices.Roles;

public class RoleCommandService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRoleCommandService
{
    public async Task<Role?> Handle(SeedRolesCommand command)
    {
        foreach (ERoles role in Enum.GetValues(typeof(ERoles)))
        {
            if(!await roleRepository.ExistsByNameAsync(role))
            {
                await roleRepository.AddAsync(new Role(role));
            }
        }

        await unitOfWork.CompleteAsync();

        return new Role(ERoles.SUPPLIER);
    }
}