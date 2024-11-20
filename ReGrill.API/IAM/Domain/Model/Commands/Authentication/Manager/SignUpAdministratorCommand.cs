namespace ReGrill.API.IAM.Domain.Model.Commands.Authentication.Manager;

public record SignUpAdministratorCommand(string UserName, string Email, string Password,
    string PhoneNumber, string Name, string Surname);