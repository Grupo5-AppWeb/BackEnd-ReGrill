using ReGrill.API.Profile.Domain.Model.Aggregates;
using ReGrill.API.Profile.Domain.Model.Commands;
using ReGrill.API.Profile.Domain.Repositories;
using ReGrill.API.Profile.Domain.Services;
using ReGrill.API.Shared.Domain.Repositories;
using ReGrill.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ReGrill.API.Profile.Application.Internal.CommandServices;

public class UserCommandService(IUserRepository userRepository, IUnitOfWork unitOfWork)
    : IUserCommandService
{
    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = await userRepository.FindByDniAsync(command.Dni);

        if (user != null)
            throw new Exception("User already exists");

        user = new User(command);

            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                return null;
            }

            return user;
        }
    }


     
