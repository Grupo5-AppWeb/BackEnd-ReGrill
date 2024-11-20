using ReGrill.API.IAM.Application.Internal.OutboundContext;
using ReGrill.API.IAM.Domain.Model.Aggregates.Management;
using ReGrill.API.IAM.Domain.Model.Commands;
using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Manager;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.Exceptions;
using ReGrill.API.IAM.Domain.Model.ValueObjects;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.IAM.Domain.Repositories.Users;
using ReGrill.API.IAM.Domain.Services.Users.Administration;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Application.Internal.CommandServices.Users;

public class AdministratorCommandService(
    IUnitOfWork unitOfWork,
    IAdministratorRepository administratorRepository,
    IHashingService hashingService,
    IAdministratorCredentialRepository administratorCredentialRepository,
    ITokenService tokenService) : IAdministratorCommandService
{
    public async Task<int> Handle(SignUpAdministratorCommand command)
    {
        try
        {
            if (await administratorRepository.ExistsByEmailAsync(command.Email))
                throw new EmailAlreadyExistException(command.Email);
            
     
            
            // Add Admin
            
            await administratorRepository.AddAsync(new Administrator(command.UserName, command.Email, new Role(ERoles.ADMINISTRATOR), command.Name,
                command.PhoneNumber, command.Surname));

            await unitOfWork.CompleteAsync();
            
            var userId = await administratorRepository.FindIdByEmailAsync(command.Email);
            
        
            
            await unitOfWork.CompleteAsync();

            return userId;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while creating the user: {ex.Message}");
        }
    }

    public async Task<dynamic?> Handle(SignInCommand command)
    {
        try
        {
            var user = await administratorRepository.FindByEmailAsync(command.Email);

            if (user is null)
                throw new EmailDoesntExistException();

            var userCredential = await administratorCredentialRepository.FindByIdAsync(user.Id);

            if (!hashingService.VerifyHash(command.Password, userCredential!.Argon2IdUserHash[..24],
                    userCredential!.Argon2IdUserHash[24..]))
                throw new InvalidPasswordException();

            var token = tokenService.GenerateToken(new
            {
                Id = user.Id,
                PasswordHash = userCredential.Argon2IdUserHash,
                Role = user.Role
            });
            
            return new
            {
                User = user, 
                Token = token
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}