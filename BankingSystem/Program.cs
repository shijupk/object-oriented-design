using BankingSystem.Abstractions;
using BankingSystem.Features;

namespace BankingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Initialize system components
        var transactions = new List<Transaction>();

        INotificationService emailNotificationService = new EmailNotificationService();
        var authenticationService = new AuthenticationService();
        var authorizationService = new AuthorizationService();
        var reportingService = new ReportingService(transactions);
        var transactionService = new TransactionService();
        var loanService = new LoanService();

        // Step 2: Create customers and accounts
        var customer1 = new Customer("John Doe", "john@example.com");
        var customer2 = new Customer("Jane Smith", "jane@example.com");

        Account savingsAccount1 = new SavingsAccount("SAV-001");
        Account checkingAccount1 = new CheckingAccount("CHK-001");
        Account savingsAccount2 = new SavingsAccount("SAV-002");

        customer1.AddAccount(savingsAccount1);
        customer1.AddAccount(checkingAccount1);
        customer2.AddAccount(savingsAccount2);

        // Step 3: Authenticate and authorize users
        var isAuthenticated = authenticationService.Authenticate(customer1, "password123");
        var isAuthorized = authorizationService.Authorize(customer1, "customer");

        if (isAuthenticated && isAuthorized)
        {
            // Step 4: Perform transactions
            var depositTransaction = new Transaction(null, savingsAccount1, 500m, TransactionType.Deposit);
            transactionService.ExecuteTransaction(depositTransaction);
            transactions.Add(depositTransaction);

            var withdrawalTransaction = new Transaction(savingsAccount1, null, 200m, TransactionType.Withdrawal);
            transactionService.ExecuteTransaction(withdrawalTransaction);
            transactions.Add(withdrawalTransaction);

            var transferTransaction =
                new Transaction(savingsAccount1, checkingAccount1, 100m, TransactionType.Transfer);
            transactionService.ExecuteTransaction(transferTransaction);
            transactions.Add(transferTransaction);

            emailNotificationService.Notify(customer1, "Your transactions have been processed successfully.");
        }

        // Step 5: Apply for a loan
        var loan = loanService.ApplyForLoan(customer2, 10000m, 0.05m, 5);
        loanService.MakeRepayment(loan, 2000m);

        // Step 6: Generate account report
        var savingsReport1 = reportingService.GenerateAccountReport(savingsAccount1);
        savingsReport1.PrintReport();

        var checkingReport1 = reportingService.GenerateAccountReport(checkingAccount1);
        checkingReport1.PrintReport();

        // Step 7: Additional operations (e.g., loan repayment, further transactions)
        loanService.MakeRepayment(loan, 1500m);
    }
}