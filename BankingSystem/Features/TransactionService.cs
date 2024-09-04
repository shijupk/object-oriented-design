using BankingSystem.Abstractions;

namespace BankingSystem.Features;

public class Transaction
{
    public Account SourceAccount { get; }
    public Account DestinationAccount { get; }
    public decimal Amount { get; }
    public DateTime Date { get; }
    public TransactionType Type { get; }

    public Transaction(Account sourceAccount, Account destinationAccount, decimal amount, TransactionType type)
    {
        SourceAccount = sourceAccount;
        DestinationAccount = destinationAccount;
        Amount = amount;
        Type = type;
        Date = DateTime.Now;
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal,
    Transfer
}

public class TransactionService
{
    public void ExecuteTransaction(Transaction transaction)
    {
        switch (transaction.Type)
        {
            case TransactionType.Deposit:
                transaction.DestinationAccount.Deposit(transaction.Amount);
                break;
            case TransactionType.Withdrawal:
                transaction.SourceAccount.Withdraw(transaction.Amount);
                break;
            case TransactionType.Transfer:
                transaction.SourceAccount.Withdraw(transaction.Amount);
                transaction.DestinationAccount.Deposit(transaction.Amount);
                break;
        }

        Console.WriteLine($"Transaction completed: {transaction.Type} of {transaction.Amount:C} on {transaction.Date}");
    }
}