namespace RestaurentReservationSystem.Abstractions;

public class Reservation
{
    public Customer Customer { get; private set; }
    public Table Table { get; }
    public DateTime ReservationTime { get; private set; }
    public int NumberOfGuests { get; private set; }
    public ReservationStatus Status { get; private set; }

    public Reservation(Customer customer, Table table, DateTime reservationTime, int numberOfGuests)
    {
        Customer = customer;
        Table = table;
        ReservationTime = reservationTime;
        NumberOfGuests = numberOfGuests;
        Status = ReservationStatus.Booked;
        table.MarkAsReserved();
    }

    public void Cancel()
    {
        Status = ReservationStatus.Cancelled;
        Table.MarkAsAvailable();
    }

    public void Complete()
    {
        Status = ReservationStatus.Completed;
    }
}

public enum ReservationStatus
{
    Booked,
    Cancelled,
    Completed
}