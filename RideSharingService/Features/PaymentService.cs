namespace RideSharingService.Features;

public interface IPaymentProcessor
{
    void ProcessPayment(Ride ride, decimal amount);
}

public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(Ride ride, decimal amount)
    {
        // Implement credit card payment processing
        Console.WriteLine(
            $"Processing credit card payment of {amount:C} for ride from {ride.PickupLocation} to {ride.DropoffLocation}");
    }
}

public class PaymentService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public PaymentService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public void Charge(Ride ride, decimal amount)
    {
        _paymentProcessor.ProcessPayment(ride, amount);
    }
}