using InMemoryDatabase.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryDatabase.Features.Join
{
    public interface IJoinStrategy
    {
        List<Dictionary<string, object>> Execute(ITable table1, ITable table2, string column1, string column2);
    }

}
