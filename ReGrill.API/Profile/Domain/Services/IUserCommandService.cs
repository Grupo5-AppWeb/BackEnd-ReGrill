using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Profile.Domain.Model.Commands;

namespace ReGrill.API.Profile.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
}