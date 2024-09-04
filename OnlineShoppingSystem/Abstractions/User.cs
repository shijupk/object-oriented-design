namespace OnlineShoppingSystem.Abstractions;

public class User
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }

    public User(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}