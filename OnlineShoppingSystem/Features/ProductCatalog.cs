using OnlineShoppingSystem.Abstractions;

namespace OnlineShoppingSystem.Features;

public class ProductCatalog : IProductCatalog
{
    private readonly List<Product> _products;

    public ProductCatalog()
    {
        _products = new List<Product>();
    }

    public Product GetProductById(string productId)
    {
        return _products.FirstOrDefault(p => p.Id == productId);
    }

    public List<Product> SearchProducts(string query)
    {
        return _products.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}