using OnlineShoppingSystem.Abstractions;

namespace OnlineShoppingSystem.Features;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users;

    public UserRepository()
    {
        _users = new List<User>();
    }

    public User GetUserById(string userId)
    {
        return _users.FirstOrDefault(u => u.Id == userId);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}