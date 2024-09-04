using OnlineShoppingSystem.Abstractions;

namespace OnlineShoppingSystem.Features;

public class PaymentProcessor : IPaymentProcessor
{
    private readonly PaymentMethod _paymentMethod;

    public PaymentProcessor(PaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public void ProcessPayment(Order order)
    {
        _paymentMethod.Pay(order);
    }
}