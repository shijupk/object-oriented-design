using InMemoryDatabase.Abstractions;

namespace InMemoryDatabase.Features;

public class Table : ITable
{
    private readonly string _autoIncrementColumn;
    private readonly string _primaryKey;
    private int _autoIncrementId = 1;
    public List<Row> Rows { get; } = [];

    public Table(string name, List<string> columnNames, string autoIncrementColumn = null, string primaryKey = null)
    {
        Name = name;
        ColumnNames = columnNames;
        _autoIncrementColumn = autoIncrementColumn;
        _primaryKey = primaryKey;
        if (_autoIncrementColumn != null && !ColumnNames.Contains(_autoIncrementColumn))
        {
            throw new Exception($"Auto-increment column {_autoIncrementColumn} is not part of the table definition.");
        }

        if (_primaryKey != null && !ColumnNames.Contains(_primaryKey))
        {
            throw new Exception($"Primary key column {_primaryKey} is not part of the table definition.");
        }
    }

    public List<string> ColumnNames { get; }

    public string Name { get; }

    public void InsertRow(Dictionary<string, object> data)
    {
        if (_autoIncrementColumn != null && !data.ContainsKey(_autoIncrementColumn))
        {
            data[_autoIncrementColumn] = _autoIncrementId++;
        }

        // Handle primary key constraint
        if (_primaryKey != null && data.ContainsKey(_primaryKey))
        {
            var existingRow = Rows.FirstOrDefault(row => row.Columns[_primaryKey].Equals(data[_primaryKey]));
            if (existingRow != null)
            {
                throw new Exception(
                    $"Primary key violation: The value '{data[_primaryKey]}' for column '{_primaryKey}' already exists.");
            }
        }

        var row = new Row();
        foreach (var column in ColumnNames)
        {
            if (data.ContainsKey(column))
            {
                row.Columns[column] = data[column];
            }
            else
            {
                row.Columns[column] = null;
            }
        }

        Rows.Add(row);
    }

    public List<Row> Select(Func<Row, bool> predicate)
    {
        return predicate == null ? Rows : Rows.Where(predicate).ToList();
    }

    public void Update(Func<Row, bool> predicate, Action<Row> updateAction)
    {
        foreach (var row in Rows.Where(predicate))
        {
            updateAction(row);
        }
    }

    public void Delete(Func<Row, bool> predicate)
    {
        Rows.RemoveAll(row => predicate(row));
    }
}