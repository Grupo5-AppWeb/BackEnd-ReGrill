namespace ReGrill.API.Profile.Interfaces.Resources;

public record CreateUserResource(
 string Dni ,
 string FirstName ,
 string LastName ,
 string Email ,
 string Password);