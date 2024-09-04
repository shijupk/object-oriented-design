using OnlineShoppingSystem.Abstractions;

namespace OnlineShoppingSystem.Features;

public class ShoppingCart : IShoppingCart
{
    private readonly Dictionary<Product, int> _products;

    public ShoppingCart()
    {
        _products = new Dictionary<Product, int>();
    }

    public void AddProduct(Product product, int quantity)
    {
        if (_products.ContainsKey(product))
        {
            _products[product] += quantity;
        }
        else
        {
            _products.Add(product, quantity);
        }
    }

    public void RemoveProduct(string productId)
    {
        var productToRemove = _products.Keys.FirstOrDefault(p => p.Id == productId);
        if (productToRemove != null)
        {
            _products.Remove(productToRemove);
        }
    }

    public decimal GetTotalAmount()
    {
        return _products.Sum(p => p.Key.Price * p.Value);
    }

    public void ClearCart()
    {
        _products.Clear();
    }

    public Dictionary<Product, int> GetProducts()
    {
        return _products;
    }
}