using ReGrill.API.IAM.Domain.Model.Commands.Role;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;

namespace ReGrill.API.IAM.Domain.Services.Roles;

public interface IRoleCommandService
{
    Task<Role?> Handle(SeedRolesCommand command);
}