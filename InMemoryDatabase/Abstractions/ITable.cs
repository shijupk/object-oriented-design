namespace InMemoryDatabase.Abstractions;

public interface ITable
{
    string Name { get; }
    List<string> ColumnNames { get; }
    void InsertRow(Dictionary<string, object> data);
    List<Row> Select(Func<Row, bool> predicate);
    void Update(Func<Row, bool> predicate, Action<Row> updateAction);
    void Delete(Func<Row, bool> predicate);
}