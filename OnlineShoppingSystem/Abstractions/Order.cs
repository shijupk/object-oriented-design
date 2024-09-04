namespace OnlineShoppingSystem.Abstractions;

public class Order
{
    public string Id { get; private set; }
    public User User { get; private set; }
    public Dictionary<Product, int> Products { get; private set; }
    public decimal TotalAmount { get; private set; }
    public OrderStatus Status { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public Order(User user, Dictionary<Product, int> products)
    {
        Id = Guid.NewGuid().ToString();
        User = user;
        Products = products;
        TotalAmount = products.Sum(p => p.Key.Price * p.Value);
        Status = OrderStatus.Created;
        PaymentStatus = PaymentStatus.Pending;
    }
}