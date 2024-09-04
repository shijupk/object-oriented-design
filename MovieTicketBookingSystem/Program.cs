using MovieTicketBookingSystem.Abstractions;
using MovieTicketBookingSystem.Features;

namespace MovieTicketBookingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Setup movie catalog
        var movieService = new MovieService();
        var movie = new Movie("M001", "Inception", "A mind-bending thriller", TimeSpan.FromMinutes(148));
        movieService.AddMovie(movie);

        // Setup theater and showtimes
        var theater = new Theater("T001", "Grand Cinema");
        var screen = new Screen("S001", "Screen 1", 100);
        theater.Screens.Add(screen);

        var showtimeService = new ShowtimeService();
        var showtime = new Showtime("ST001", movie, screen, DateTime.Now.AddHours(2));
        showtimeService.AddShowtime(showtime);

        // Setup seat selection
        var seatSelectionService = new SeatSelectionService(showtimeService);
        var availableSeats = seatSelectionService.GetAvailableSeats("ST001");
        seatSelectionService.SelectSeat(availableSeats[0]); // Selecting the first available seat
        seatSelectionService.SelectSeat(availableSeats[1]); // Selecting the second available seat

        // Create booking
        var user = new User("U001", "John Doe", "john@example.com");
        var bookingService = new BookingService(new PaymentService());

        var booking =
            bookingService.CreateBooking(user, showtime, new List<Seat> { availableSeats[0], availableSeats[1] });

        // Process payment and confirm booking
        var paymentMethod = new CreditCardPayment();
        booking.PaymentMethod = paymentMethod;
        bookingService.ConfirmBooking(booking);
    }
}