using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Profile.Domain.Model.Queries;
using ReGrill.API.Profile.Domain.Repositories;
using ReGrill.API.Profile.Domain.Services;

namespace ReGrill.API.Profile.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByDniQuery query)
    {
        return await userRepository.FindByDniAsync(query.Dni);
    }
    
     
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        var guidFromInt = new Guid(query.UserId.ToString("D").PadLeft(32, '0'));
        return await userRepository.FindByIdAsync(guidFromInt);
    }
}