using Microsoft.EntityFrameworkCore;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.ValueObjects;
using ReGrill.API.IAM.Domain.Repositories.Roles;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;

public class RoleRepository(AppDbContext context) : BaseRepository<Role>(context), IRoleRepository
{
    public async Task<Role?> FindByNameAsync(ERoles name) => await Context.Set<Role>().FirstOrDefaultAsync(r => r.Name == name);
    

    public async Task<bool> ExistsByNameAsync(ERoles name) => await Context.Set<Role>().AnyAsync(r => r.Name == name);
    
}