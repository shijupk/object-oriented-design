namespace InMemoryDatabase.Abstractions;

public class Row
{
    public Dictionary<string, object> Columns { get; set; } = new();
}