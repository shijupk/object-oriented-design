using HotelBookingSystem.Entities;
using HotelBookingSystem.Services;

namespace HotelBookingSystem.Features;

public class LoggingBookingServiceDecorator : BookingServiceDecorator
{
    public LoggingBookingServiceDecorator(IBookingService bookingService) : base(bookingService)
    {
    }

    public override Booking CreateBooking(int userId, int roomId, DateTime checkIn, DateTime checkOut)
    {
        Console.WriteLine(
            $"[LOG] Creating booking: UserId={userId}, RoomId={roomId}, CheckIn={checkIn}, CheckOut={checkOut}");
        var booking = base.CreateBooking(userId, roomId, checkIn, checkOut);
        Console.WriteLine($"[LOG] Booking created with ID: {booking.Id}");
        return booking;
    }

    public override void CancelBooking(int bookingId)
    {
        Console.WriteLine($"[LOG] Cancelling booking with ID: {bookingId}");
        base.CancelBooking(bookingId);
        Console.WriteLine($"[LOG] Booking with ID: {bookingId} cancelled");
    }

    public override IEnumerable<Booking> GetUserBookings(int userId)
    {
        Console.WriteLine($"[LOG] Fetching bookings for UserId={userId}");
        var bookings = base.GetUserBookings(userId);
        Console.WriteLine($"[LOG] Retrieved {bookings.Count()} bookings for UserId={userId}");
        return bookings;
    }
}