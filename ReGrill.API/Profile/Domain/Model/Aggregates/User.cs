using ReGrill.API.Profile.Domain.Model.Commands;

namespace ReGrill.API.Profile.Domain.Model.Aggregates;

public partial class User
{
    
    public int Id { get; set; }
    
    public string Dni { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User()
    {
        
    }

    public User(CreateUserCommand command)
    {
        Dni = command.Dni;
        FirstName = command.FirstName;
        LastName = command.LastName;
        Email = command.Email;
        Password = command.Password;
    }
    
    
}