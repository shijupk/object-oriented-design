using VendingMachine.Abstractions;

namespace VendingMachine.Features;

public class Inventory
{
    private readonly Dictionary<int, ProductSlot> _slots;

    public Inventory()
    {
        _slots = new Dictionary<int, ProductSlot>();
    }

    public void AddProductSlot(int slotNumber, ProductSlot slot)
    {
        _slots[slotNumber] = slot;
    }

    public ProductSlot GetProductSlot(int slotNumber)
    {
        return _slots.ContainsKey(slotNumber) ? _slots[slotNumber] : null;
    }

    public bool IsProductAvailable(int slotNumber)
    {
        var slot = GetProductSlot(slotNumber);
        return slot != null && slot.IsAvailable();
    }

    public void DispenseProduct(int slotNumber)
    {
        var slot = GetProductSlot(slotNumber);
        slot?.Dispense();
    }

    public void RestockProduct(int slotNumber, int quantity)
    {
        var slot = GetProductSlot(slotNumber);
        slot?.Restock(quantity);
    }
}