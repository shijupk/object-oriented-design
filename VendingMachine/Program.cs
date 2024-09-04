using VendingMachine.Abstractions;
using VendingMachine.Features;

namespace VendingMachine;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Initialize inventory and products
        var inventory = new Inventory();
        inventory.AddProductSlot(1, new ProductSlot(new Product("Soda", 1.50m, "1"), 10));
        inventory.AddProductSlot(2, new ProductSlot(new Product("Chips", 1.00m, "2"), 5));
        inventory.AddProductSlot(3, new ProductSlot(new Product("Candy", 0.75m,"3"), 20));

        // Step 2: Initialize the vending machine
        var vendingMachine = new Features.VendingMachine(inventory);

        // Step 3: Select a payment method and purchase a product
        IPaymentMethod cashPayment = new CashPayment();
        ((CashPayment)cashPayment).InsertCash(2.00m);
        vendingMachine.SelectPaymentMethod(cashPayment);
        vendingMachine.PurchaseProduct(1);

        // Step 4: Restock a product
        vendingMachine.RestockProduct(1, 10);
    }
}