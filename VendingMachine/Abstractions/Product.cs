namespace VendingMachine.Abstractions;

public class Product
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public string Code { get; private set; }

    public Product(string name, decimal price, string code)
    {
        Name = name;
        Price = price;
        Code = code;
    }
}