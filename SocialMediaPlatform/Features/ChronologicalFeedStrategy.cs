using SocialMediaPlatform.Abstractions;

namespace SocialMediaPlatform.Features;

public interface IFeedStrategy
{
    List<Post> GenerateFeed(User user);
}

public class ChronologicalFeedStrategy : IFeedStrategy
{
    public List<Post> GenerateFeed(User user)
    {
        // Generate feed based on chronological order
        return user.Posts.OrderByDescending(post => post.Timestamp).ToList();
    }
}