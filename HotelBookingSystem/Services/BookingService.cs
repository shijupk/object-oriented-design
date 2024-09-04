using HotelBookingSystem.Entities;
using HotelBookingSystem.Repository;

namespace HotelBookingSystem.Services;

public interface IBookingService
{
    Booking CreateBooking(int userId, int roomId, DateTime checkIn, DateTime checkOut);
    void CancelBooking(int bookingId);

    IEnumerable<Booking> GetUserBookings(int userId);
    // Additional methods as needed
}

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly INotificationService _notificationService;
    private readonly IRoomRepository _roomRepository;
    private readonly IUserRepository _userRepository;

    public BookingService(
        IBookingRepository bookingRepository,
        IRoomRepository roomRepository,
        IUserRepository userRepository,
        INotificationService notificationService)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
        _userRepository = userRepository;
        _notificationService = notificationService;
    }

    public Booking CreateBooking(int userId, int roomId, DateTime checkIn, DateTime checkOut)
    {
        var user = _userRepository.GetUserById(userId)
                   ?? throw new ArgumentException("Invalid user ID.");
        var room = _roomRepository.GetRoomById(roomId)
                   ?? throw new ArgumentException("Invalid room ID.");

        if (!room.IsAvailable)
        {
            throw new InvalidOperationException("Room is not available.");
        }

        // Check for overlapping bookings
        var availableRooms = _roomRepository.GetAvailableRooms(room.Hotel.Id, checkIn, checkOut);
        if (!availableRooms.Any(r => r.Id == roomId))
        {
            throw new InvalidOperationException("Room is not available for the selected dates.");
        }

        var booking = new Booking(user, room, checkIn, checkOut);
        _bookingRepository.AddBooking(booking);

        // Update room availability if necessary
        room.IsAvailable = false; // Simplified; in reality, manage availability per date

        // Notify user
        _notificationService.Notify(user, $"Your booking (ID: {booking.Id}) is confirmed.");

        return booking;
    }

    public void CancelBooking(int bookingId)
    {
        var booking = _bookingRepository.GetBookingById(bookingId)
                      ?? throw new ArgumentException("Invalid booking ID.");

        if (booking.Status == BookingStatus.Cancelled)
        {
            throw new InvalidOperationException("Booking is already cancelled.");
        }

        booking.Status = BookingStatus.Cancelled;

        // Update room availability
        booking.Room.IsAvailable = true; // Simplified

        // Notify user
        _notificationService.Notify(booking.User, $"Your booking (ID: {booking.Id}) has been cancelled.");
    }

    public IEnumerable<Booking> GetUserBookings(int userId)
    {
        return _bookingRepository.GetBookingsByUser(userId);
    }
}