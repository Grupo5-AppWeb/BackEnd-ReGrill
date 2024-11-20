using Microsoft.EntityFrameworkCore;
using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Profile.Domain.Repositories;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.Profile.Infrastucture.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context)
: BaseRepository<User>(context), IUserRepository

{
    public async Task<User?>FindByDniAsync(string dni)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(p => p.Dni == dni);
    }
    
    
    
    
}