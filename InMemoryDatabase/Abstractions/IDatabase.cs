using InMemoryDatabase.Features.Join;

namespace InMemoryDatabase.Abstractions;

public interface IDatabase
{
    void CreateTable(string tableName, List<string> columns, string autoIncrementColumn = null,
        string primaryKey = null);

    void InsertIntoTable(string tableName, Dictionary<string, object> data);
    List<Row> SelectFromTable(string tableName, IQueryStrategy queryStrategy, Func<Row, bool> predicate = null);
    void UpdateTable(string tableName, Func<Row, bool> predicate, Action<Row> updateAction);
    void DeleteFromTable(string tableName, Func<Row, bool> predicate);

    public void AddForeignKey(string referencingTable, string referencingColumn, string referencedTable,
        string referencedColumn);

    List<Dictionary<string, object>> JoinTables(string table1Name, string table2Name, string column1, string column2,
        IJoinStrategy joinStrategy);
}