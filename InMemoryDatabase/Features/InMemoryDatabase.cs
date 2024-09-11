using InMemoryDatabase.Abstractions;
using InMemoryDatabase.Features.Join;

namespace InMemoryDatabase.Features;

public class InMemoryDatabase : IDatabase
{
    private readonly Dictionary<string, List<ForeignKeyConstraint>> _foreignKeys = new();
    private readonly Dictionary<string, ITable> _tables = new();

    public void CreateTable(string tableName, List<string> columns, string autoIncrementColumn = null,
        string primaryKeyColumn = null)
    {
        if (!_tables.ContainsKey(tableName))
        {
            _tables[tableName] = TableFactory.CreateTable(tableName, columns, autoIncrementColumn, primaryKeyColumn);
            _foreignKeys[tableName] = new List<ForeignKeyConstraint>();
        }
        else
        {
            throw new Exception($"Table {tableName} already exists.");
        }
    }


    public void AddForeignKey(string referencingTable, string referencingColumn, string referencedTable,
        string referencedColumn)
    {
        if (_tables.ContainsKey(referencingTable) && _tables.ContainsKey(referencedTable))
        {
            var foreignKey = new ForeignKeyConstraint(_tables[referencedTable], referencingColumn, referencedColumn);
            _foreignKeys[referencingTable].Add(foreignKey);
        }
        else
        {
            throw new Exception("One of the tables does not exist.");
        }
    }

    public void InsertIntoTable(string tableName, Dictionary<string, object> data)
    {
        if (_tables.ContainsKey(tableName))
        {
            // Validate foreign keys
            if (_foreignKeys.ContainsKey(tableName))
            {
                foreach (var foreignKey in _foreignKeys[tableName])
                {
                    if (!foreignKey.Validate(data))
                    {
                        throw new Exception(
                            $"Foreign key constraint failed in table {tableName} for column {foreignKey}");
                    }
                }
            }

            _tables[tableName].InsertRow(data);
        }
        else
        {
            throw new Exception($"Table {tableName} does not exist.");
        }
    }

    public List<Row> SelectFromTable(string tableName, IQueryStrategy queryStrategy, Func<Row, bool> predicate = null)
    {
        if (_tables.ContainsKey(tableName))
        {
            return queryStrategy.Execute(_tables[tableName], predicate);
        }

        throw new Exception($"Table {tableName} does not exist.");
    }

    public void UpdateTable(string tableName, Func<Row, bool> predicate, Action<Row> updateAction)
    {
        if (_tables.ContainsKey(tableName))
        {
            _tables[tableName].Update(predicate, updateAction);
        }
        else
        {
            throw new Exception($"Table {tableName} does not exist.");
        }
    }

    public void DeleteFromTable(string tableName, Func<Row, bool> predicate)
    {
        if (_tables.ContainsKey(tableName))
        {
            _tables[tableName].Delete(predicate);
        }
        else
        {
            throw new Exception($"Table {tableName} does not exist.");
        }
    }

    // New method for performing joins
    public List<Dictionary<string, object>> JoinTables(string table1Name, string table2Name, string column1,
        string column2, IJoinStrategy joinStrategy)
    {
        if (_tables.ContainsKey(table1Name) && _tables.ContainsKey(table2Name))
        {
            var table1 = _tables[table1Name];
            var table2 = _tables[table2Name];

            return joinStrategy.Execute(table1, table2, column1, column2);
        }

        throw new Exception($"One or both of the tables {table1Name} or {table2Name} do not exist.");
    }
}