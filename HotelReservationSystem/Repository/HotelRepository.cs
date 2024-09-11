using HotelReservationSystem.Abstractions;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Repository
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Hotel AddHotel(Hotel hotel);
        Task<Hotel> GetHotelByIdAsync(int id);

        Task<IEnumerable<Hotel>> GetHotelsByLocationAsync(string location);
        // Additional methods as needed
    }

    public class HotelRepository : IHotelRepository
    {
        private readonly BookingContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public HotelRepository(BookingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Hotel AddHotel(Hotel hotel)
        {
            if (hotel.IsTransient())
            {
                return _context.Hotel
                    .Add(hotel)
                    .Entity;
            }

            return hotel;
        }

        public async Task<Hotel> GetHotelByIdAsync(int id)
        {
            var hotel = await _context.Hotel
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();
            return hotel;
        }

        public async Task<IEnumerable<Hotel>> GetHotelsByLocationAsync(string location)
        {
            var hotels = await _context.Hotel
                .Where(b => b.Location == location)
                .ToListAsync();
            return hotels;
        }
    }
}
