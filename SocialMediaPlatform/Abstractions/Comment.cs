namespace SocialMediaPlatform.Abstractions;

public class Comment
{
    public User Author { get; private set; }
    public Post Post { get; private set; }
    public string Content { get; private set; }
    public DateTime Timestamp { get; private set; }

    public Comment(User author, Post post, string content)
    {
        Author = author;
        Post = post;
        Content = content;
        Timestamp = DateTime.UtcNow;
    }
}