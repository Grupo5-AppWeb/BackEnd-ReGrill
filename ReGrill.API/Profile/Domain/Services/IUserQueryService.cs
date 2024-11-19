using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Profile.Domain.Model.Queries;

namespace ReGrill.API.Profile.Domain.Services;

public interface IUserQueryService
{
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByDniQuery query);
    
}