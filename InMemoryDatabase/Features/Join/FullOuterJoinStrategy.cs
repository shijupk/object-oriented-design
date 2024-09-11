using InMemoryDatabase.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryDatabase.Features.Join
{
    public class FullOuterJoinStrategy : IJoinStrategy
    {
        public List<Dictionary<string, object>> Execute(ITable table1, ITable table2, string column1, string column2)
        {
            var result = new List<Dictionary<string, object>>();

            var matchedTable2Rows = new HashSet<Row>(); // To track rows from table2 that have been matched

            // Left-side join (all rows from table1)
            foreach (var row1 in table1.Select(null))
            {
                bool matchFound = false;
                foreach (var row2 in table2.Select(null))
                {
                    if (row1.Columns[column1].Equals(row2.Columns[column2]))
                    {
                        matchFound = true;
                        matchedTable2Rows.Add(row2);

                        var joinedRow = new Dictionary<string, object>();

                        // Add columns from table1
                        foreach (var column in row1.Columns)
                        {
                            joinedRow[$"{table1.Name}.{column.Key}"] = column.Value;
                        }

                        // Add columns from table2
                        foreach (var column in row2.Columns)
                        {
                            joinedRow[$"{table2.Name}.{column.Key}"] = column.Value;
                        }

                        result.Add(joinedRow);
                    }
                }

                // If no match found, add row1 with nulls for table2
                if (!matchFound)
                {
                    var joinedRow = new Dictionary<string, object>();

                    // Add columns from table1
                    foreach (var column in row1.Columns)
                    {
                        joinedRow[$"{table1.Name}.{column.Key}"] = column.Value;
                    }

                    // Add nulls for columns from table2
                    foreach (var column in table2.ColumnNames)
                    {
                        joinedRow[$"{table2.Name}.{column}"] = null;
                    }

                    result.Add(joinedRow);
                }
            }

            // Right-side join (remaining rows from table2 that were not matched)
            foreach (var row2 in table2.Select(null))
            {
                if (!matchedTable2Rows.Contains(row2))
                {
                    var joinedRow = new Dictionary<string, object>();

                    // Add nulls for columns from table1
                    foreach (var column in table1.ColumnNames)
                    {
                        joinedRow[$"{table1.Name}.{column}"] = null;
                    }

                    // Add columns from table2
                    foreach (var column in row2.Columns)
                    {
                        joinedRow[$"{table2.Name}.{column.Key}"] = column.Value;
                    }

                    result.Add(joinedRow);
                }
            }

            return result;
        }
    }

}
