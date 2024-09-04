namespace SocialMediaPlatform.Abstractions;

public class User
{
    public string Username { get; private set; }
    public string Email { get; private set; }
    public List<Post> Posts { get; } = new();

    public User(string username, string email)
    {
        Username = username;
        Email = email;
    }

    public void CreatePost(string content)
    {
        var post = new Post(this, content);
        Posts.Add(post);
    }

    // Other user-related methods
}