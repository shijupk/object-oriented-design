namespace VendingMachine.Abstractions;

public class ProductSlot
{
    public Product Product { get; private set; }
    public int Quantity { get; private set; }

    public ProductSlot(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public bool IsAvailable()
    {
        return Quantity > 0;
    }

    public void Dispense()
    {
        if (IsAvailable())
        {
            Quantity--;
        }
    }

    public void Restock(int quantity)
    {
        Quantity += quantity;
    }
}