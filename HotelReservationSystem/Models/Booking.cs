using HotelReservationSystem.Abstractions;

namespace HotelReservationSystem.Models;

public enum BookingStatus
{
    Confirmed,
    Cancelled,
    Completed
}

public class Booking : Entity, IAggregateRoot
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Room Room { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public BookingStatus Status { get; set; }
    //public Payment Payment { get; set; }

    //public Booking(int id, User user, int userId, Room room, DateTime checkIn, DateTime checkOut)
    //{
    //    Id = id;
    //    UserId = userId;
    //    User = user;
    //    Room = room;
    //    CheckIn = checkIn;
    //    CheckOut = checkOut;
    //    Status = BookingStatus.Confirmed;
    //}
}