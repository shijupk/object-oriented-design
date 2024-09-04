using ContentManagementSystem.Abstractions;

namespace ContentManagementSystem.Features;

public interface IContentFactory
{
    Content CreateContent(string type, string title, string author, string data);
}

public class ContentFactory : IContentFactory
{
    public Content CreateContent(string type, string title, string author, string data)
    {
        return type.ToLower() switch
        {
            "article" => new Article(title, author, data),
            "media" => new Media(title, author, data),
            _ => throw new ArgumentException("Unknown content type.")
        };
    }
}