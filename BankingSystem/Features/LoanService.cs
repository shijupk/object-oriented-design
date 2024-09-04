using BankingSystem.Abstractions;

namespace BankingSystem.Features;

public class Loan
{
    public Customer Customer { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Balance { get; private set; }
    public decimal InterestRate { get; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    public Loan(Customer customer, decimal amount, decimal interestRate, DateTime startDate, DateTime endDate)
    {
        Customer = customer;
        Amount = amount;
        Balance = amount;
        InterestRate = interestRate;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void MakeRepayment(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Loan repayment made: {amount:C}. Remaining balance: {Balance:C}");
        }
        else
        {
            throw new InvalidOperationException("Repayment amount exceeds loan balance.");
        }
    }

    public decimal CalculateInterest()
    {
        return Balance * InterestRate;
    }
}

public class LoanService
{
    public Loan ApplyForLoan(Customer customer, decimal amount, decimal interestRate, int termInYears)
    {
        var startDate = DateTime.Now;
        var endDate = startDate.AddYears(termInYears);
        var loan = new Loan(customer, amount, interestRate, startDate, endDate);
        customer.AddAccount(new SavingsAccount($"LN-{Guid.NewGuid()}")); // Associate loan with an account
        Console.WriteLine($"Loan approved for {customer.Name}: {amount:C} at {interestRate:P} interest.");
        return loan;
    }

    public void MakeRepayment(Loan loan, decimal amount)
    {
        loan.MakeRepayment(amount);
    }
}