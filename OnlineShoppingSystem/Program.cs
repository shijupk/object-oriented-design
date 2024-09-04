using OnlineShoppingSystem.Abstractions;
using OnlineShoppingSystem.Features;

namespace OnlineShoppingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Setup product catalog
        var catalog = new ProductCatalog();
        catalog.AddProduct(new Product("1", "Laptop", "High performance laptop", 1200));
        catalog.AddProduct(new Product("2", "Smartphone", "Latest model smartphone", 800));

        // Setup user repository and create a user
        var userRepository = new UserRepository();
        var user = new User("U001", "Alice", "alice@example.com");
        userRepository.AddUser(user);

        // Create shopping cart
        var cart = new ShoppingCart();
        cart.AddProduct(catalog.GetProductById("1"), 1);
        cart.AddProduct(catalog.GetProductById("2"), 2);

        // Process order
        var paymentMethod = new CreditCardPayment();
        var paymentProcessor = new PaymentProcessor(paymentMethod);
        var orderService = new OrderService(paymentProcessor);

        var order = orderService.CreateOrder(user, cart);
        orderService.ProcessOrder(order);
    }
}