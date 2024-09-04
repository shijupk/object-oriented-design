using OnlineShoppingSystem.Abstractions;

namespace OnlineShoppingSystem.Features;

public class OrderService : IOrderService
{
    private readonly IPaymentProcessor _paymentProcessor;

    public OrderService(IPaymentProcessor paymentProcessor)
    {
        _paymentProcessor = paymentProcessor;
    }

    public Order CreateOrder(User user, IShoppingCart cart)
    {
        var products = cart.GetProducts();
        if (products.Count == 0)
        {
            throw new InvalidOperationException("Cart is empty");
        }

        var order = new Order(user, products);
        Console.WriteLine($"Order {order.Id} created for user {user.Name}");
        return order;
    }

    public void ProcessOrder(Order order)
    {
        _paymentProcessor.ProcessPayment(order);
        if (order.PaymentStatus == PaymentStatus.Completed)
        {
            order.Status = OrderStatus.Processing;
            Console.WriteLine($"Order {order.Id} is now being processed");
            // Further processing like shipping can be done here
        }
    }
}