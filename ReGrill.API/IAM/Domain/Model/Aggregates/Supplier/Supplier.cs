using ReGrill.API.IAM.Domain.Model.Entities.Credential;
using ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;
using ReGrill.API.IAM.Domain.Model.Entities.User;
using ReGrill.API.IAM.Domain.Model.ValueObjects;

namespace ReGrill.API.IAM.Domain.Model.Aggregates.Supplier;

public partial class Supplier(string username, string email, Role role, string name, string phoneNumber, string surname)
: User(username, email, role, name, surname, phoneNumber)
{
    public Supplier() : this("", "",new Role(ERoles.SUPPLIER), "", "", "")
    {
        
    }
    public virtual SupplierCredential? SupplierCredential { get; set; }
}