namespace ReGrill.API.IAM.Domain.Model.Commands.Authentication.Credential;

public record CreateUserCredentialCommand(int UserId, string Argon2IdUserHash);