using HotelBookingSystem.Entities;
using HotelBookingSystem.Services;

namespace HotelBookingSystem.Features;

public abstract class BookingServiceDecorator : IBookingService
{
    protected readonly IBookingService _bookingService;

    protected BookingServiceDecorator(IBookingService bookingService)
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