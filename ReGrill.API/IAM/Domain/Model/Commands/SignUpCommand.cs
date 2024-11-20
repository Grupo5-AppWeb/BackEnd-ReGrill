namespace ReGrill.API.IAM.Domain.Model.Commands;

public record SignUpCommand(string UserName, string Email, string Password, string Role);