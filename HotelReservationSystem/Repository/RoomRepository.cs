using HotelReservationSystem.Abstractions;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room AddRoom(Room room);
        Task<Room> GetAsync(int id);

        Task<IEnumerable<Room>> GetAvailableRooms(int hotelId);
        // Additional methods as needed
    }

    public class RoomRepository : IRoomRepository
    {
        private readonly BookingContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public RoomRepository(BookingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Room AddRoom(Room room)
        {
            if (room.IsTransient())
            {
                return _context.Rooms
                    .Add(room)
                    .Entity;
            }

            return room;
        }

        public async Task<Room> GetAsync(int roomId)
        {
            var room = await _context.Rooms
                .Where(b => b.Id == roomId)
                .SingleOrDefaultAsync();

            return room;
        }

        public async Task<IEnumerable<Room>> GetAvailableRooms(int hotelId)
        {
            var rooms = await _context.Rooms
                .Where(b => b.HotelId == hotelId && b.IsAvailable == true)
                .ToListAsync();
            return rooms;


        }
    }
}
