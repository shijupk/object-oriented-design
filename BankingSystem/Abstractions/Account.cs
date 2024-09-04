namespace BankingSystem.Abstractions;

public abstract class Account
{
    public string AccountNumber { get; private set; }
    public decimal Balance { get; protected set; }

    protected Account(string accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0m;
    }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

public class SavingsAccount : Account
{
    public SavingsAccount(string accountNumber) : base(accountNumber)
    {
    }

    public override void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
    }
}

public class CheckingAccount : Account
{
    public CheckingAccount(string accountNumber) : base(accountNumber)
    {
    }

    public override void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            throw new InvalidOperationException("Insufficient funds.");
        }
    }
}