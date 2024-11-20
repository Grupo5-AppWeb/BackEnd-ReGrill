using Microsoft.EntityFrameworkCore;
using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Repositories.Users;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Users;

public class SupplierRepository(AppDbContext context) : BaseRepository<Supplier>(context), ISupplierRepository 
{
    public async Task<Supplier?> FindByEmailAsync(string email)
    {
        return await Context.Set<Supplier>().FirstOrDefaultAsync(w => w.Email.Equals(email));
    }

    public async Task<bool> ExistByEmailAsync(string email)
    {
        Task<bool>queryAsync = new(() =>Context.Set<Supplier>().Any(w => w.Email.Equals(email)));
        
        queryAsync.Start();
        
        var result = await queryAsync;

        return result;
    }
}