namespace MovieTicketBookingSystem.Abstractions;

public class Booking
{
    public string Id { get; }
    public User User { get; private set; }
    public Showtime Showtime { get; private set; }
    public List<Seat> Seats { get; private set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }

    public Booking(User user, Showtime showtime, List<Seat> seats)
    {
        Id = Guid.NewGuid().ToString();
        User = user;
        Showtime = showtime;
        Seats = seats;
        PaymentStatus = PaymentStatus.Pending;
        PaymentMethod = new CreditCardPayment();
    }
}

public abstract class PaymentMethod
{
    public abstract void Pay(Booking booking);
}

public class CreditCardPayment : PaymentMethod
{
    public override void Pay(Booking booking)
    {
        // Implement credit card payment processing
        Console.WriteLine($"Processing credit card payment for booking {booking.Id}");
        booking.PaymentStatus = PaymentStatus.Completed;
    }
}

public class PayPalPayment : PaymentMethod
{
    public override void Pay(Booking booking)
    {
        // Implement PayPal payment processing
        Console.WriteLine($"Processing PayPal payment for booking {booking.Id}");
        booking.PaymentStatus = PaymentStatus.Completed;
    }
}