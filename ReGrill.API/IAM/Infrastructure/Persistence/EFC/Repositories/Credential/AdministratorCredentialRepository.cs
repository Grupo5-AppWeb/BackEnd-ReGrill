using ReGrill.API.IAM.Domain.Model.Aggregates.Management;
using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Credential;

public class AdministratorCredentialRepository(AppDbContext context)
    : BaseRepository<AdministratorCredential>(context), IAdministratorCredentialRepository
{
    public async Task<AdministratorCredential?> FindByAdministratorIdAsync(int administratorId)
    {
        Task<AdministratorCredential?> queryAsync = new(() =>
        (
            from cc in Context.Set<AdministratorCredential>().ToList()
            join u in Context.Set<Administrator>().ToList() on cc.AdminId equals u.Id
            where cc.AdminId == u.Id
            select cc
        ).FirstOrDefault());

        queryAsync.Start();

        var result = await queryAsync;

        return result;
    }
}