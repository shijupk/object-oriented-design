using BankingSystem.Abstractions;

namespace BankingSystem.Features;

public class AccountReport
{
    public string AccountNumber { get; }
    public decimal Balance { get; }
    public int TotalTransactions { get; }

    public AccountReport(string accountNumber, decimal balance, int totalTransactions)
    {
        AccountNumber = accountNumber;
        Balance = balance;
        TotalTransactions = totalTransactions;
    }

    public void PrintReport()
    {
        Console.WriteLine($"Account Report for {AccountNumber}:");
        Console.WriteLine($"Balance: {Balance:C}");
        Console.WriteLine($"Total Transactions: {TotalTransactions}");
    }
}

public class ReportingService
{
    private readonly List<Transaction> _transactions;

    public ReportingService(List<Transaction> transactions)
    {
        _transactions = transactions;
    }

    public AccountReport GenerateAccountReport(Account account)
    {
        var totalTransactions = _transactions.Count(t => t.SourceAccount == account || t.DestinationAccount == account);
        return new AccountReport(account.AccountNumber, account.Balance, totalTransactions);
    }
}