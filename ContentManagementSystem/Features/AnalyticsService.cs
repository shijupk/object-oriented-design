namespace ContentManagementSystem.Features;

public class ContentAnalytics
{
    public string Title { get; private set; }
    public int Views { get; private set; }
    public int Likes { get; private set; }

    public ContentAnalytics(string title)
    {
        Title = title;
    }

    public void AddView()
    {
        Views++;
    }

    public void AddLike()
    {
        Likes++;
    }
}

public class AnalyticsService
{
    private readonly Dictionary<string, ContentAnalytics> _analyticsData;

    public AnalyticsService()
    {
        _analyticsData = new Dictionary<string, ContentAnalytics>();
    }

    public void RecordView(string title)
    {
        if (!_analyticsData.ContainsKey(title))
        {
            _analyticsData[title] = new ContentAnalytics(title);
        }

        _analyticsData[title].AddView();
    }

    public void RecordLike(string title)
    {
        if (!_analyticsData.ContainsKey(title))
        {
            _analyticsData[title] = new ContentAnalytics(title);
        }

        _analyticsData[title].AddLike();
    }

    public ContentAnalytics GetAnalytics(string title)
    {
        return _analyticsData.ContainsKey(title) ? _analyticsData[title] : null;
    }
}