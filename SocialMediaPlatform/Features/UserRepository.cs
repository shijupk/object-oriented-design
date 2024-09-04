using SocialMediaPlatform.Abstractions;

namespace SocialMediaPlatform.Features;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserByUsername(string username);
}

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public User GetUserByUsername(string username)
    {
        return _users.FirstOrDefault(u => u.Username == username);
    }
}