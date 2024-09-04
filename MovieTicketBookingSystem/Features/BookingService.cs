using MovieTicketBookingSystem.Abstractions;

namespace MovieTicketBookingSystem.Features;

public class BookingService : IBookingService
{
    private readonly IPaymentService _paymentService;

    public BookingService(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public Booking CreateBooking(User user, Showtime showtime, List<Seat> seats)
    {
        if (seats.Any(seat => seat.Status != SeatStatus.Available))
        {
            throw new InvalidOperationException("One or more seats are not available");
        }

        var booking = new Booking(user, showtime, seats);
        Console.WriteLine($"Booking {booking.Id} created for user {user.Name}");

        // Reserve the seats
        foreach (var seat in seats)
        {
            seat.Status = SeatStatus.Reserved;
        }

        return booking;
    }

    public void ConfirmBooking(Booking booking)
    {
        _paymentService.ProcessPayment(booking, booking.PaymentMethod);

        if (booking.PaymentStatus == PaymentStatus.Completed)
        {
            foreach (var seat in booking.Seats)
            {
                seat.Status = SeatStatus.Booked;
            }

            Console.WriteLine($"Booking {booking.Id} confirmed and seats are booked.");
        }
        else
        {
            Console.WriteLine($"Payment failed for booking {booking.Id}. Seats are not booked.");
        }
    }
}