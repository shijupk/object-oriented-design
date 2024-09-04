using ContentManagementSystem.Abstractions;

namespace ContentManagementSystem.Features;

public interface IContentRepository
{
    Content GetByTitle(string title);
    void AddContent(Content content);
    IEnumerable<Content> Search(SearchCriteria criteria);
}

public class ContentRepository : IContentRepository
{
    private readonly List<Content> _contents = new();

    public Content GetByTitle(string title)
    {
        return _contents.FirstOrDefault(c => c.Title == title);
    }

    public void AddContent(Content content)
    {
        _contents.Add(content);
    }

    public IEnumerable<Content> Search(SearchCriteria criteria)
    {
        return _contents.Where(c =>
            (string.IsNullOrEmpty(criteria.Title) || c.Title.Contains(criteria.Title)) &&
            (string.IsNullOrEmpty(criteria.Author) || c.Author.Contains(criteria.Author)) &&
            (!criteria.PublishedAfter.HasValue || c.PublishedAt >= criteria.PublishedAfter) &&
            (!criteria.Status.HasValue || c.Status == criteria.Status)
        );
    }
}