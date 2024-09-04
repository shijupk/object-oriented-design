using OnlineShoppingSystem.Abstractions;

namespace OnlineShoppingSystem.Features;

public abstract class PaymentMethod
{
    public abstract void Pay(Order order);
}

public class CreditCardPayment : PaymentMethod
{
    public override void Pay(Order order)
    {
        // Implement credit card payment processing
        Console.WriteLine($"Processing credit card payment for order {order.Id}");
        order.PaymentStatus = PaymentStatus.Completed;
    }
}

public class PayPalPayment : PaymentMethod
{
    public override void Pay(Order order)
    {
        // Implement PayPal payment processing
        Console.WriteLine($"Processing PayPal payment for order {order.Id}");
        order.PaymentStatus = PaymentStatus.Completed;
    }
}