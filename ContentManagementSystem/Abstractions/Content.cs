namespace ContentManagementSystem.Abstractions;

public abstract class Content
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? PublishedAt { get; private set; }
    public ContentStatus Status { get; private set; }
    public List<ContentVersion> Versions { get; }

    protected Content(string title, string author)
    {
        Title = title;
        Author = author;
        CreatedAt = DateTime.Now;
        Status = ContentStatus.Draft;
        Versions = new List<ContentVersion>();
    }

    public void Publish()
    {
        Status = ContentStatus.Published;
        PublishedAt = DateTime.Now;
    }

    public void AddVersion(ContentVersion version)
    {
        Versions.Add(version);
    }
}

public class Article : Content
{
    public string Body { get; private set; }

    public Article(string title, string author, string body) : base(title, author)
    {
        Body = body;
        AddVersion(new ContentVersion(this, body));
    }

    public void EditBody(string newBody)
    {
        Body = newBody;
        AddVersion(new ContentVersion(this, newBody));
    }
}

public class Media : Content
{
    public string FilePath { get; private set; }

    public Media(string title, string author, string filePath) : base(title, author)
    {
        FilePath = filePath;
        AddVersion(new ContentVersion(this, filePath));
    }
}

public enum ContentStatus
{
    Draft,
    Published,
    Archived
}

public class ContentVersion
{
    public Content Content { get; private set; }
    public string Data { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public ContentVersion(Content content, string data)
    {
        Content = content;
        Data = data;
        CreatedAt = DateTime.Now;
    }
}