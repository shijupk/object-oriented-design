using ContentManagementSystem.Abstractions;

namespace ContentManagementSystem.Features;

public class ContentDeliveryService
{
    private readonly IContentRepository _contentRepository;

    public ContentDeliveryService(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public string GetContent(string title)
    {
        var content = _contentRepository.GetByTitle(title);
        if (content == null || content.Status != ContentStatus.Published)
        {
            return "Content not found or not published.";
        }

        // Return content in the desired format, e.g., HTML, JSON, etc.
        return FormatContent(content);
    }

    private string FormatContent(Content content)
    {
        // Simplified formatting logic
        return content is Article article ? article.Body : $"Media file at {((Media)content).FilePath}";
    }
}