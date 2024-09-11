using InMemoryDatabase.Abstractions;

namespace InMemoryDatabase.Features.Join;

public class InnerJoinStrategy : IJoinStrategy
{
    public List<Dictionary<string, object>> Execute(ITable table1, ITable table2, string column1, string column2)
    {
        var result = new List<Dictionary<string, object>>();

        foreach (var row1 in table1.Select(null))
        {
            foreach (var row2 in table2.Select(null))
            {
                if (row1.Columns[column1].Equals(row2.Columns[column2]))
                {
                    var joinedRow = new Dictionary<string, object>();

                    // Add columns from the first table (table1)
                    foreach (var column in row1.Columns)
                    {
                        joinedRow[$"{table1.Name}.{column.Key}"] = column.Value;
                    }

                    // Add columns from the second table (table2)
                    foreach (var column in row2.Columns)
                    {
                        joinedRow[$"{table2.Name}.{column.Key}"] = column.Value;
                    }

                    result.Add(joinedRow);
                }
            }
        }

        return result;
    }
}