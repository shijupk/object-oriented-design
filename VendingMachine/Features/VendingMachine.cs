namespace VendingMachine.Features;

public class VendingMachine
{
    private readonly Inventory _inventory;
    private IPaymentMethod _paymentMethod;

    public VendingMachine(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void SelectPaymentMethod(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public void PurchaseProduct(int slotNumber)
    {
        var slot = _inventory.GetProductSlot(slotNumber);
        if (slot == null || !slot.IsAvailable())
        {
            Console.WriteLine("Product not available.");
            return;
        }

        if (_paymentMethod == null)
        {
            Console.WriteLine("No payment method selected.");
            return;
        }

        var product = slot.Product;
        if (_paymentMethod.ValidatePayment(product.Price))
        {
            _paymentMethod.ProcessPayment(product.Price);
            _inventory.DispenseProduct(slotNumber);
            Console.WriteLine($"Dispensing {product.Name}");
        }
        else
        {
            Console.WriteLine("Payment failed.");
        }
    }

    public void RestockProduct(int slotNumber, int quantity)
    {
        _inventory.RestockProduct(slotNumber, quantity);
    }
}