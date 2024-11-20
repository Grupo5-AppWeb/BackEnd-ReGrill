using ReGrill.API.IAM.Domain.Model.Commands.Authentication.Credential;
using Supplier = ReGrill.API.IAM.Domain.Model.Aggregates.Supplier.Supplier;

namespace ReGrill.API.IAM.Domain.Model.Entities.Credential;

public sealed partial class SupplierCredential(int userId, string argon2IdUserHash)
{
    public int Id { get; private set; }
    
    public int SupplierId { get; private set;  } = userId;

    public string Argon2IdUserHash { get; private set; } = argon2IdUserHash;

    public Supplier Supplier { get; private set; } = null!;
    
    public SupplierCredential() : this(0, string.Empty)
    {
        this.Id = 0;
    }

    public SupplierCredential(CreateUserCredentialCommand command) : this(command.UserId, command.Argon2IdUserHash)
    {
    }
}