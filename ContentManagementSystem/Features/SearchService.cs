using ContentManagementSystem.Abstractions;

namespace ContentManagementSystem.Features;

public class SearchCriteria
{
    public string Title { get; set; }
    public string Author { get; set; }
    public DateTime? PublishedAfter { get; set; }
    public ContentStatus? Status { get; set; }
}

public class SearchService
{
    private readonly IContentRepository _contentRepository;

    public SearchService(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public IEnumerable<Content> Search(SearchCriteria criteria)
    {
        return _contentRepository.Search(criteria);
    }
}