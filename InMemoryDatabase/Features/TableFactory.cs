using InMemoryDatabase.Abstractions;

namespace InMemoryDatabase.Features;

public class TableFactory
{
    public static ITable CreateTable(string tableName, List<string> columns, string autoIncrementColumn = null,
        string primaryKey = null)
    {
        return new Table(tableName, columns, autoIncrementColumn, primaryKey);
    }
}