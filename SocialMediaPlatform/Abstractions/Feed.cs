using SocialMediaPlatform.Features;

namespace SocialMediaPlatform.Abstractions;

public class Feed
{
    private readonly IFeedStrategy _feedStrategy;

    public Feed(IFeedStrategy feedStrategy)
    {
        _feedStrategy = feedStrategy;
    }

    public List<Post> GetPosts(User user)
    {
        return _feedStrategy.GenerateFeed(user);
    }
}