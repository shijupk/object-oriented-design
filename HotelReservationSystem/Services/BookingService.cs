using HotelReservationSystem.Models;
using HotelReservationSystem.Repository;

namespace HotelReservationSystem.Services
{
    public interface IBookingService
    {
        Task<Booking> CreateBooking(int userId, int roomId, DateTime checkIn, DateTime checkOut);
        void CancelBooking(int bookingId);

        Task<IEnumerable<Booking>> GetUserBookings(int userId);
    }
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IUserRepository _userRepository;

        public BookingService(
            IBookingRepository bookingRepository,
            IRoomRepository roomRepository,
            IUserRepository userRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
            _userRepository = userRepository;

        }

        public async Task<Booking> CreateBooking(int userId, int roomId, DateTime checkIn, DateTime checkOut)
        {
            var user = await _userRepository.GetAsync(userId).ConfigureAwait(false)
                       ?? throw new ArgumentException("Invalid user ID.");
            var room = await _roomRepository.GetAsync(roomId).ConfigureAwait(false)
                       ?? throw new ArgumentException("Invalid room ID.");

            if (!room.IsAvailable)
            {
                throw new InvalidOperationException("Room is not available.");
            }

            var availableRooms = await _roomRepository.GetAvailableRooms(room.Hotel.Id).ConfigureAwait(false);
            if (availableRooms.All(r => r.Id != roomId))
            {
                throw new InvalidOperationException("Room is not available for the selected dates.");
            }

            var booking = new Booking();
            //_bookingRepository.AddBooking(booking);

            // Update room availability if necessary
            room.IsAvailable = false; // Simplified; in reality, manage availability per date

            // Notify user
            //_notificationService.Notify(user, $"Your booking (ID: {booking.Id}) is confirmed.");

            return booking;

        }

        public void CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetUserBookings(int userId)
        {
            return _bookingRepository.GetBookingsByUser(userId);
        }
    }
}
