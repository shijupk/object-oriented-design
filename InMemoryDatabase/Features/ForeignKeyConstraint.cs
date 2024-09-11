using InMemoryDatabase.Abstractions;

namespace InMemoryDatabase.Features;

public class ForeignKeyConstraint
{
    private readonly string _referencedColumn;
    private readonly ITable _referencedTable;
    private readonly string _referencingColumn;

    public ForeignKeyConstraint(ITable referencedTable, string referencingColumn, string referencedColumn)
    {
        _referencedTable = referencedTable;
        _referencingColumn = referencingColumn;
        _referencedColumn = referencedColumn;
    }

    public bool Validate(Dictionary<string, object> data)
    {
        if (data.ContainsKey(_referencingColumn))
        {
            var referencingValue = data[_referencingColumn];
            return _referencedTable.Select(row => row.Columns[_referencedColumn].Equals(referencingValue)).Any();
        }

        return false;
    }
}