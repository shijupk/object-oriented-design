using InMemoryDatabase.Abstractions;

namespace InMemoryDatabase.Features;

public class FilterByColumnStrategy : IQueryStrategy
{
    private readonly string _columnName;
    private readonly object _columnValue;

    public FilterByColumnStrategy(string columnName, object columnValue)
    {
        _columnName = columnName;
        _columnValue = columnValue;
    }

    public List<Row> Execute(ITable table, Func<Row, bool> predicate)
    {
        return table.Select(row => row.Columns[_columnName].Equals(_columnValue));
    }
}