using InMemoryDatabase.Abstractions;
using InMemoryDatabase.Features;
using InMemoryDatabase.Features.Join;

namespace InMemoryDatabase;

public class Program
{
    public static void Main(string[] args)
    {
        IDatabase db = new Features.InMemoryDatabase();

        // Create Users table with auto-incrementing UserId and a primary key
        db.CreateTable("Users", new List<string> { "UserId", "Name", "Email" }, "UserId", "UserId");

        // Create Orders table with an auto-incrementing OrderId and a primary key
        db.CreateTable("Orders", new List<string> { "OrderId", "UserId", "Amount" }, "OrderId", "OrderId");

        // Add foreign key constraint on Orders.UserId referencing Users.UserId
        db.AddForeignKey("Orders", "UserId", "Users", "UserId");

        // Insert rows into Users table
        db.InsertIntoTable("Users",
            new Dictionary<string, object> { { "Name", "John Doe" }, { "Email", "john@example.com" } });
        db.InsertIntoTable("Users",
            new Dictionary<string, object> { { "Name", "Jane Doe" }, { "Email", "jane@example.com" } });

        // Insert rows into Orders table
        db.InsertIntoTable("Orders",
            new Dictionary<string, object> { { "UserId", 1 }, { "Amount", 100 } }); // Valid FK
        db.InsertIntoTable("Orders",
            new Dictionary<string, object> { { "UserId", 2 }, { "Amount", 150 } }); // Valid FK

        // Attempt to insert an invalid foreign key (UserId = 3 does not exist)
        try
        {
            db.InsertIntoTable("Orders", new Dictionary<string, object> { { "UserId", 3 }, { "Amount", 199.99 } });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message); // Should print foreign key violation error
        }
        // Use BasicQueryStrategy to get all rows
        var basicStrategy = new BasicQueryStrategy();
        var allUsers = db.SelectFromTable("Users", basicStrategy);
        Console.WriteLine("All Users:");
        foreach (var user in allUsers)
        {
            Console.WriteLine($"{user.Columns["UserId"]}: {user.Columns["Name"]} ({user.Columns["Email"]})");
        }
        // Use FilterByColumnStrategy to filter users by name
        var filterByNameStrategy = new FilterByColumnStrategy("Name", "Jane Doe");
        var filteredUsers = db.SelectFromTable("Users", filterByNameStrategy);
        Console.WriteLine("\nFiltered Users (Name = 'Jane Doe'):");
        foreach (var user in filteredUsers)
        {
            Console.WriteLine($"{user.Columns["UserId"]}: {user.Columns["Name"]} ({user.Columns["Email"]})");
        }

        // Perform an INNER JOIN between Users and Orders on UserId
        var innerJoinStrategy = new InnerJoinStrategy();
        var joinResult = db.JoinTables("Users", "Orders", "UserId", "UserId", innerJoinStrategy);

        // Print the result of the join
        Console.WriteLine("Join Result (INNER JOIN on Users.UserId = Orders.UserId):");
        foreach (var row in joinResult)
        {
            Console.WriteLine($"{row["Users.Name"]} ({row["Users.Email"]}) - Order Amount: {row["Orders.Amount"]}");
        }

    }
}