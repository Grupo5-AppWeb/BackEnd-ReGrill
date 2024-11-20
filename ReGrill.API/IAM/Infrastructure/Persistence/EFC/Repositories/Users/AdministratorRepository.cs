using Microsoft.EntityFrameworkCore;
using ReGrill.API.IAM.Domain.Model.Aggregates.Management;
using ReGrill.API.IAM.Domain.Repositories.Users;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Users;

public class AdministratorRepository(AppDbContext context) : BaseRepository<Administrator>(context), IAdministratorRepository
{
    public async Task<Administrator?> FindByEmailAsync(string email)
    {
        return await Context.Set<Administrator>().FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        Task<bool>queryAsync = new (() => Context.Set<Administrator>().Any(a => a.Email.Equals(email)));
        
        queryAsync.Start();

        var result = await queryAsync;
        
        return result;
    }

    public async Task<int> FindIdByEmailAsync(string email)
        => await Task.Run(() =>
        (
            from wr in Context.Set<Administrator>().ToList()
            where wr.Email.Equals(email)
            select wr.Id
        ).FirstOrDefault());
}