using HotelBookingSystem.Entities;

namespace HotelBookingSystem.Services;

public interface IPaymentGatewayFactory
{
    IPaymentGateway CreatePaymentGateway(PaymentMethod method);
}

public class PaymentGatewayFactory : IPaymentGatewayFactory
{
    public IPaymentGateway CreatePaymentGateway(PaymentMethod method)
    {
        switch (method)
        {
            case PaymentMethod.CreditCard:
                return new CreditCardPaymentGateway();
            case PaymentMethod.PayPal:
                return new PayPalPaymentGateway();
            default:
                throw new ArgumentException("Invalid payment method.");
        }
    }
}

public enum PaymentMethod
{
    CreditCard,
    PayPal
}

public interface IPaymentGateway
{
    void ProcessPayment(Payment payment);
}

public class CreditCardPaymentGateway : IPaymentGateway
{
    public void ProcessPayment(Payment payment)
    {
        // Implement credit card payment processing
        Console.WriteLine($"Processing credit card payment of {payment.Amount}");
    }
}

public class PayPalPaymentGateway : IPaymentGateway
{
    public void ProcessPayment(Payment payment)
    {
        // Implement PayPal payment processing
        Console.WriteLine($"Processing PayPal payment of {payment.Amount}");
    }
}