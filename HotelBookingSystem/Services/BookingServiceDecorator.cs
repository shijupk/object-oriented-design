using HotelBookingSystem.Entities;

namespace HotelBookingSystem.Services;

public class BookingServiceDecorator : IBookingService
{
    protected readonly IBookingService _bookingService;

    public BookingServiceDecorator(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public virtual Booking CreateBooking(int userId, int roomId, DateTime checkIn, DateTime checkOut)
    {
        return _bookingService.CreateBooking(userId, roomId, checkIn, checkOut);
    }

    public virtual void CancelBooking(int bookingId)
    {
        _bookingService.CancelBooking(bookingId);
    }

    public virtual IEnumerable<Booking> GetUserBookings(int userId)
    {
        return _bookingService.GetUserBookings(userId);
    }
}

public class LoggingBookingServiceDecorator : BookingServiceDecorator
{
    public LoggingBookingServiceDecorator(IBookingService bookingService) : base(bookingService)
    {
    }

    public override Booking CreateBooking(int userId, int roomId, DateTime checkIn, DateTime checkOut)
    {
        Console.WriteLine(
            $"Creating booking for User: {userId}, Room: {roomId}, CheckIn: {checkIn}, CheckOut: {checkOut}");
        var booking = base.CreateBooking(userId, roomId, checkIn, checkOut);
        Console.WriteLine($"Booking created with ID: {booking.Id}");
        return booking;
    }

    public override void CancelBooking(int bookingId)
    {
        Console.WriteLine($"Cancelling booking with ID: {bookingId}");
        base.CancelBooking(bookingId);
        Console.WriteLine($"Booking with ID: {bookingId} cancelled");
    }

    public override IEnumerable<Booking> GetUserBookings(int userId)
    {
        Console.WriteLine($"Fetching bookings for User: {userId}");
        var bookings = base.GetUserBookings(userId);
        Console.WriteLine($"Fetched {bookings.Count()} bookings for User: {userId}");
        return bookings;
    }
}