using HotelBookingSystem.Entities;

namespace HotelBookingSystem.Repository;

public interface IUserRepository
{
    void AddUser(User user);
    User GetUserById(int id);

    User GetUserByEmail(string email);
    // Additional methods as needed
}

public interface IHotelRepository
{
    void AddHotel(Hotel hotel);
    Hotel GetHotelById(int id);

    IEnumerable<Hotel> GetHotelsByLocation(string location);
    // Additional methods as needed
}

public interface IRoomRepository
{
    void AddRoom(Room room);
    Room GetRoomById(int id);

    IEnumerable<Room> GetAvailableRooms(int hotelId, DateTime checkIn, DateTime checkOut);
    // Additional methods as needed
}

public interface IBookingRepository
{
    void AddBooking(Booking booking);
    Booking GetBookingById(int id);

    IEnumerable<Booking> GetBookingsByUser(int userId);
    // Additional methods as needed
}

public interface IPaymentRepository
{
    void AddPayment(Payment payment);

    Payment GetPaymentById(int id);
    // Additional methods as needed
}

public interface IReviewRepository
{
    void AddReview(Review review);

    IEnumerable<Review> GetReviewsByHotel(int hotelId);
    // Additional methods as needed
}