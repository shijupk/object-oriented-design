using SocialMediaPlatform.Abstractions;

namespace SocialMediaPlatform.Features;

public class SocialMediaPlatform
{
    private readonly IFeedStrategy _feedStrategy;
    private readonly INotificationService _notificationService;
    private readonly IUserRepository _userRepository;

    public SocialMediaPlatform(
        IUserRepository userRepository,
        IFeedStrategy feedStrategy,
        INotificationService notificationService)
    {
        _userRepository = userRepository;
        _feedStrategy = feedStrategy;
        _notificationService = notificationService;
    }

    public void RegisterUser(string username, string email)
    {
        var user = new User(username, email);
        _userRepository.AddUser(user);
    }

    public void PostContent(User user, string content)
    {
        user.CreatePost(content);
        // Notify followers, etc.
    }

    // Other platform-wide methods
}