using ReGrill.API.IAM.Application.Internal.OutboundContext;
using ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;
using ReGrill.API.IAM.Domain.Model.Commands;
using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Supplier;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.Exceptions;
using ReGrill.API.IAM.Domain.Model.ValueObjects;
using ReGrill.API.IAM.Domain.Repositories.Credential;
using ReGrill.API.IAM.Domain.Repositories.Users;
using ReGrill.API.IAM.Domain.Services.Users.Supply;
using ReGrill.API.Shared.Domain.Repositories;

namespace ReGrill.API.IAM.Application.Internal.CommandServices.Users;

public class SupplierCommandService(IUnitOfWork unitOfWork, 
    ISupplierRepository supplierRepository,
    IHashingService hashingService,
    ITokenService tokenService,
    ISupplierCredentialRepository supplierCredentialRepository ) : ISupplierCommandService

{
    public async Task<Supplier?> Handle(SignUpSupplierCommand command)
    {
        try
        {
            if (await supplierRepository.ExistByEmailAsync(command.Email))
                throw new EmailAlreadyExistException(command.Email);

          
            
            
            var user = new Supplier(command.UserName, command.Email, new Role(ERoles.SUPPLIER), command.PhoneNumber, command.Name, command.Surname);

            await supplierRepository.AddAsync(user);

            await unitOfWork.CompleteAsync();

            return user;
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
            var user = await supplierRepository.FindByEmailAsync(command.Email);

            if (user is null)
                throw new EmailDoesntExistException();

            var userCredential = await supplierCredentialRepository.FindBySupplierIdAsync(user.Id);

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
                Token = token,
                User = user
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}