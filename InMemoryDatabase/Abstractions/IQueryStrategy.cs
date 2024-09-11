namespace InMemoryDatabase.Abstractions;

public interface IQueryStrategy
{
    List<Row> Execute(ITable table, Func<Row, bool> predicate);
}