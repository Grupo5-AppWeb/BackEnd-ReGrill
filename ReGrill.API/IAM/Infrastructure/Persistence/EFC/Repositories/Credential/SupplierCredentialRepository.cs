using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.IAM.Infrastructure.Persistence.EFC.Repositories.Credential;

public class SupplierCredentialRepository(AppDbContext context) :BaseRepository<SupplierCredential>(context), ISupplierCredentialRepository
{
    public async Task<SupplierCredential?> FindBySupplierIdAsync(int supplierId)
    {
        Task<SupplierCredential?> queryAsync = new(() =>
        (
            from cc in Context.Set<SupplierCredential>().ToList()
            join u in Context.Set<Supplier>().ToList() on cc.SupplierId equals u.Id
            where cc.SupplierId == u.Id
            select cc
        ).FirstOrDefault());
        
        queryAsync.Start();

        var result = await queryAsync;

        return result;
    }
}