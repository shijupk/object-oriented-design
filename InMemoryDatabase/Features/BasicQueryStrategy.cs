using InMemoryDatabase.Abstractions;

namespace InMemoryDatabase.Features;

public class BasicQueryStrategy : IQueryStrategy
{
    public List<Row> Execute(ITable table, Func<Row, bool> predicate)
    {
        return table.Select(predicate);
    }
}

// Another strategy can be implemented for more advanced querying