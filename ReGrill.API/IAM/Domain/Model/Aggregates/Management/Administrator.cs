using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.Entities.User;
using ReGrill.API.IAM.Domain.Model.ValueObjects;

namespace ReGrill.API.IAM.Domain.Model.Aggregates.Management;

public partial class Administrator(string username, string email, Role role, string name, string phoneNumber, string surname)
    : User(username, email, role, name, surname, phoneNumber)
{
    public Administrator() : this("", "", new Role(ERoles.ADMINISTRATOR), "", "", "")
    {

    }
    public virtual AdministratorCredential? AdministratorCredential { get; set; }
}