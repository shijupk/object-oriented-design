namespace RestaurentReservationSystem.Features;

public interface IPaymentProcessor
{
    bool ProcessPayment(decimal amount);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public bool ProcessPayment(decimal amount)
    {
        // Simulate credit card payment processing
        Console.WriteLine($"Processing credit card payment of {amount:C}");
        return true;
    }
}

public class PaymentService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void Charge(decimal amount)
    {
        if (_paymentProcessor.ProcessPayment(amount))
        {
            Console.WriteLine("Payment successful.");
        }
        else
        {
            Console.WriteLine("Payment failed.");
        }
    }
}