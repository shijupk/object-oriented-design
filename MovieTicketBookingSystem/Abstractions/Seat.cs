namespace MovieTicketBookingSystem.Abstractions;

public class Seat
{
    public string Id { get; private set; }
    public SeatStatus Status { get; set; }

    public Seat(string id)
    {
        Id = id;
        Status = SeatStatus.Available;
    }
}