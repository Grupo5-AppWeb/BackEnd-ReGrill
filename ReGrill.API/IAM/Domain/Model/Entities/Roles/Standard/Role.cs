using ReGrill.API.IAM.Domain.Model.ValueObjects;

namespace ReGrill.API.IAM.Domain.Model.Entities.Roles.Standard;

public partial class Role(ERoles name)
{
    
    public long Id { get; private set; }
    
    public ERoles Name { get; private set; } = name;

    public string GetStringName() => Name.ToString();
    
    public static Role GetDefaultRole() =>  new Role(ERoles.ADMINISTRATOR);
    
}