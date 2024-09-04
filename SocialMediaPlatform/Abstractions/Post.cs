namespace SocialMediaPlatform.Abstractions;

public class Post
{
    public User Author { get; private set; }
    public string Content { get; private set; }
    public DateTime Timestamp { get; private set; }
    public List<Comment> Comments { get; } = new();
    public List<Like> Likes { get; } = new();

    public Post(User author, string content)
    {
        Author = author;
        Content = content;
        Timestamp = DateTime.UtcNow;
    }

    public void AddComment(User user, string commentText)
    {
        var comment = new Comment(user, this, commentText);
        Comments.Add(comment);
    }

    public void AddLike(User user)
    {
        var like = new Like(user, this);
        Likes.Add(like);
    }

    // Other post-related methods
}