namespace ReGrill.API.Profile.Interfaces.Resources;

public record UserResource(
    long Id,
    string Dni,
    string FirstName,
    string LastName,
    string Email,
    string Password);