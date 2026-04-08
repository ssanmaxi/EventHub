using EventBooking.Domain.Enums;
namespace EventBooking.Domain.Models;

public class User
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public Role Role { get; private set; }

    public string? PasswordHash { get; private set; }
    public string? Email { get; private set; }

    public User(string name, string email, string passwordHash, Role role)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        Id = Guid.NewGuid();
        Role = role;
    }
    
    
}