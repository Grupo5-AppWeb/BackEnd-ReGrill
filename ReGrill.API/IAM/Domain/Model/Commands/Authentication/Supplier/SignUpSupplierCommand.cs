namespace ReGrill.API.IAM.Domain.Model.Commands.Authentication.Supplier;

public record SignUpSupplierCommand(string UserName, string Email, string Password, string PhoneNumber, 
    string Surname, string Name);