using ContentManagementSystem.Abstractions;
using ContentManagementSystem.Features;

namespace ContentManagementSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Initialize repositories, services, and factories
        IContentRepository contentRepository = new ContentRepository();
        IContentFactory contentFactory = new ContentFactory();
        INotificationService notificationService = new EmailNotificationService();
        var contentDeliveryService = new ContentDeliveryService(contentRepository);
        var searchService = new SearchService(contentRepository);
        var analyticsService = new AnalyticsService();

        // Step 2: Create some users and roles
        var adminUser = new User("Admin", "admin@example.com");
        var adminRole = new Role("Administrator");
        adminRole.AddPermission(new Permission("CreateContent"));
        adminRole.AddPermission(new Permission("PublishContent"));
        adminUser.AssignRole(adminRole);

        var editorUser = new User("Editor", "editor@example.com");
        var editorRole = new Role("Editor");
        editorRole.AddPermission(new Permission("CreateContent"));
        editorRole.AddPermission(new Permission("EditContent"));
        editorUser.AssignRole(editorRole);

        // Step 3: Create some content
        var article = contentFactory.CreateContent("article", "My First Article", adminUser.Username,
            "This is the body of my first article.");
        var media = contentFactory.CreateContent("media", "My First Image", editorUser.Username,
            "/images/my_first_image.png");

        contentRepository.AddContent(article);
        contentRepository.AddContent(media);

        // Step 4: Publish content
        article.Publish();
        notificationService.Notify(adminUser, $"Your content '{article.Title}' has been published.");
        contentRepository.AddContent(article); // Update repository with published content

        // Step 5: Deliver content
        var deliveredContent = contentDeliveryService.GetContent("My First Article");
        Console.WriteLine($"Delivered Content: {deliveredContent}");

        // Step 6: Search for content
        var searchCriteria = new SearchCriteria { Title = "First", Status = ContentStatus.Published };
        var searchResults = searchService.Search(searchCriteria);
        Console.WriteLine("Search Results:");
        foreach (var content in searchResults)
        {
            Console.WriteLine($" - {content.Title} by {content.Author}");
        }

        // Step 7: Record analytics
        analyticsService.RecordView(article.Title);
        analyticsService.RecordLike(article.Title);

        var analytics = analyticsService.GetAnalytics(article.Title);
        Console.WriteLine($"Content Analytics for '{article.Title}': Views={analytics.Views}, Likes={analytics.Likes}");

        // Additional operations like editing content, managing user roles, etc., can be added similarly.
    }
}