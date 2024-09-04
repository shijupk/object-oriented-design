namespace RestaurentReservationSystem.Abstractions;

public class Table
{
    public int TableNumber { get; private set; }
    public int Capacity { get; private set; }
    public bool IsAvailable { get; private set; }

    public Table(int tableNumber, int capacity)
    {
        TableNumber = tableNumber;
        Capacity = capacity;
        IsAvailable = true;
    }

    public void MarkAsReserved()
    {
        IsAvailable = false;
    }

    public void MarkAsAvailable()
    {
        IsAvailable = true;
    }
}