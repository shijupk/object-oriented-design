using BankingSystem.Abstractions;

namespace BankingSystem.Features;

public class AuthenticationService
{
    public bool Authenticate(User user, string password)
    {
        // Simulate authentication process
        Console.WriteLine($"Authenticating {user.Name}...");
        return true; // Assume authentication is successful
    }
}

public class AuthorizationService
{
    public bool Authorize(User user, string role)
    {
        // Simulate authorization process
        Console.WriteLine($"Authorizing {user.Name} for role {role}...");
        return true; // Assume authorization is successful
    }
}