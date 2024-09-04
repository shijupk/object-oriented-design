namespace VendingMachine.Features;

public interface IPaymentMethod
{
    bool ValidatePayment(decimal amount);
    void ProcessPayment(decimal amount);
}

public class CashPayment : IPaymentMethod
{
    private decimal _insertedAmount;

    public bool ValidatePayment(decimal amount)
    {
        return _insertedAmount >= amount;
    }

    public void ProcessPayment(decimal amount)
    {
        if (_insertedAmount >= amount)
        {
            Console.WriteLine($"Payment successful. Change returned: {_insertedAmount - amount:C}");
            _insertedAmount = 0; // Reset after payment
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }

    public void InsertCash(decimal amount)
    {
        _insertedAmount += amount;
    }
}

public class CardPayment : IPaymentMethod
{
    public bool ValidatePayment(decimal amount)
    {
        // Implement card validation logic (e.g., check card balance)
        return true; // Simplified
    }

    public void ProcessPayment(decimal amount)
    {
        // Implement card payment processing
        Console.WriteLine($"Card payment of {amount:C} processed successfully.");
    }
}