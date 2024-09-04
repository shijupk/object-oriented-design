namespace MovieTicketBookingSystem.Abstractions;

public enum SeatStatus
{
    Available,
    Reserved,
    Booked
}

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed
}

public interface IMovieService
{
    Movie GetMovieDetails(string movieId);
    List<Movie> GetMoviesByTitle(string title);
}

public interface IShowtimeService
{
    List<Showtime> GetShowtimesForMovie(string movieId);
    Showtime GetShowtimeDetails(string showtimeId);
}

public interface ISeatSelectionService
{
    List<Seat> GetAvailableSeats(string showtimeId);
    void SelectSeat(Seat seat);
}

public interface IBookingService
{
    Booking CreateBooking(User user, Showtime showtime, List<Seat> seats);
    void ConfirmBooking(Booking booking);
}

public interface IPaymentService
{
    void ProcessPayment(Booking booking, PaymentMethod paymentMethod);
}