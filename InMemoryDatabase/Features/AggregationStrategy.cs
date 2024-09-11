using InMemoryDatabase.Abstractions;

namespace InMemoryDatabase.Features;

public class AggregationStrategy : IQueryStrategy
{
    private readonly string _columnName;
    private readonly string _operation; // "SUM", "AVG"

    public AggregationStrategy(string columnName, string operation)
    {
        _columnName = columnName;
        _operation = operation.ToUpper();
    }

    public List<Row> Execute(ITable table, Func<Row, bool> predicate)
    {
        var selectedRows = table.Select(predicate);

        // Ensure the column contains numeric values
        var values = selectedRows
            .Select(row => row.Columns[_columnName])
            .Where(val => val is int || val is double || val is decimal)
            .Cast<decimal>();

        decimal result = 0;

        if (_operation == "SUM")
        {
            result = values.Sum();
        }
        else if (_operation == "AVG")
        {
            result = values.Any() ? values.Average() : 0;
        }

        // Return a single row with the result of the aggregation
        var resultRow = new Row();
        resultRow.Columns[_columnName] = result;
        return new List<Row> { resultRow };
    }
}