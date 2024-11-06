namespace ReGrill.API.Profile.Domain.Model.Commands;

public record CreateUserCommand(
    string Dni,
    string FirstName,
    string LastName,
    string Email,
    string Password
    );