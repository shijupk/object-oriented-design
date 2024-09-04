namespace SocialMediaPlatform.Abstractions;

public class Like
{
    public User User { get; private set; }
    public Post Post { get; private set; }
    public DateTime Timestamp { get; private set; }

    public Like(User user, Post post)
    {
        User = user;
        Post = post;
        Timestamp = DateTime.UtcNow;
    }
}