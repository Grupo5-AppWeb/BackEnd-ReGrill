using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.Profile.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?>  FindByDniAsync(string dni);
}