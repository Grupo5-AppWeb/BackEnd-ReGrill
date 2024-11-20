using ReGrill.API.IAM.Domain.Model.Commands.Role;
using ReGrill.API.IAM.Domain.Model.Queries;
using ReGrill.API.IAM.Domain.Services.Roles;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ReGrill.API.IAM.Infrastructure.Poblation.Roles;

public class DatabaseInitializer(IRoleCommandService roleCommandService, 
    IRoleQueryService roleQueryService, 
    AppDbContext appDbContext)
{
    public async Task InitializeAsync()
    {
        // Check if the Role table is empty

        var result = 
            await roleQueryService.Handle(new GetAllRolesQuery());
        
        if (!result.Any())
        {
            // Prepopulate the Role table
            await roleCommandService.Handle(new SeedRolesCommand());
        }
        
        // Check if the WorkerArea table is empty 
   
    }
}