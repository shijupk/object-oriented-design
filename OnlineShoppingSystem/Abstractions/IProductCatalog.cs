namespace OnlineShoppingSystem.Abstractions;

public enum OrderStatus
{
    Created,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed
}

public interface IProductCatalog
{
    Product GetProductById(string productId);
    List<Product> SearchProducts(string query);
}

public interface IShoppingCart
{
    void AddProduct(Product product, int quantity);
    void RemoveProduct(string productId);
    public Dictionary<Product, int> GetProducts();
    decimal GetTotalAmount();
    void ClearCart();
}

public interface IOrderService
{
    Order CreateOrder(User user, IShoppingCart cart);
    void ProcessOrder(Order order);
}

public interface IPaymentProcessor
{
    void ProcessPayment(Order order);
}

public interface IUserRepository
{
    User GetUserById(string userId);
}