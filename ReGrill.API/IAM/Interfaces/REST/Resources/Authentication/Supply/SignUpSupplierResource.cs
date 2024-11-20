namespace ReGrill.API.IAM.Interfaces.REST.Resources.Authentication.Supply;

public record SignUpSupplierResource(string UserName, string Email, string Password, string PhoneNumber, 
    string Surname, string Name);