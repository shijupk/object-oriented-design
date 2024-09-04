using SocialMediaPlatform.Abstractions;

namespace SocialMediaPlatform.Features;

public interface IPostFactory
{
    Post CreatePost(User user, string content);
}

public class TextPostFactory : IPostFactory
{
    public Post CreatePost(User user, string content)
    {
        return new Post(user, content);
    }
}