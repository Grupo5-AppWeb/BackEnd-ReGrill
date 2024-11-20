namespace ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Administration;

public record SignUpAdministratorResource(string UserName, string Email, string Password, 
    string PhoneNumber, string Name, string Surname);