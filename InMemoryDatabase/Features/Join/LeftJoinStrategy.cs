using InMemoryDatabase.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryDatabase.Features.Join
{
    public class LeftJoinStrategy : IJoinStrategy
    {
        public List<Dictionary<string, object>> Execute(ITable table1, ITable table2, string column1, string column2)
        {
            var result = new List<Dictionary<string, object>>();

            foreach (var row1 in table1.Select(null))
            {
                bool matchFound = false;
                foreach (var row2 in table2.Select(null))
                {
                    if (row1.Columns[column1].Equals(row2.Columns[column2]))
                    {
                        matchFound = true;
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

                // If no match found in table2, add row1 with nulls for table2 columns
                if (!matchFound)
                {
                    var joinedRow = new Dictionary<string, object>();

                    // Add columns from the first table (table1)
                    foreach (var column in row1.Columns)
                    {
                        joinedRow[$"{table1.Name}.{column.Key}"] = column.Value;
                    }

                    // Add nulls for columns from the second table (table2)
                    foreach (var column in table2.ColumnNames)
                    {
                        joinedRow[$"{table2.Name}.{column}"] = null;
                    }

                    result.Add(joinedRow);
                }
            }

            return result;
        }
    }

}
