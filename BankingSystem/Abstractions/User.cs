namespace BankingSystem.Abstractions;

public abstract class User
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    protected User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

public class Customer : User
{
    public List<Account> Accounts { get; }

    public Customer(string name, string email) : base(name, email)
    {
        Accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        Accounts.Add(account);
    }
}