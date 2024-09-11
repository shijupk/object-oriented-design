using HotelReservationSystem.Abstractions;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Repository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Booking AddBooking(Booking booking);
        Task<Booking> GetBookingById(int id);

        Task<IEnumerable<Booking>> GetBookingsByUser(int userId);
        // Additional methods as needed
    }

    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public BookingRepository(BookingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Booking AddBooking(Booking booking)
        {
            if (booking.IsTransient())
            {
                return _context.Bookings
                    .Add(booking)
                    .Entity;
            }
            return booking;

        }

        public async Task<Booking> GetBookingById(int id)
        {
            var booking = await _context.Bookings
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();

            return booking;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUser(int userId)
        {
            var bookings = await _context.Bookings
                .Where(b => b.User.Id == userId)
                .ToListAsync();

            return bookings;
        }
    }
}
