namespace HotelBookingSystem.Entities;

public class User
{
    public int Id { get; }
    public string Username { get; private set; }
    public string Email { get; private set; }

    public string PasswordHash { get; private set; }
    // Additional properties like Role, ProfileInfo, etc.

    public User(string username, string email, string passwordHash)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }

    // Methods related to User, e.g., UpdateProfile, ChangePassword
}

public class Hotel
{
    public int Id { get; }
    public string Name { get; private set; }
    public string Location { get; private set; }
    public List<Room> Rooms { get; private set; } = new();
    public List<Review> Reviews { get; private set; } = new();

    public Hotel(string name, string location)
    {
        Name = name;
        Location = location;
    }

    // Methods related to Hotel, e.g., AddRoom, RemoveRoom, AddReview
}

public class Room
{
    public int Id { get; }
    public string RoomNumber { get; private set; }
    public RoomType Type { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; set; }

    public Room(string roomNumber, RoomType type, decimal price)
    {
        RoomNumber = roomNumber;
        Type = type;
        Price = price;
        IsAvailable = true;
    }

    // Methods related to Room, e.g., UpdatePrice, ChangeAvailability
}

public class Booking
{
    public int Id { get; }
    public User User { get; private set; }
    public Room Room { get; private set; }
    public DateTime CheckIn { get; private set; }
    public DateTime CheckOut { get; private set; }
    public BookingStatus Status { get; set; }
    public Payment Payment { get; }

    public Booking(User user, Room room, DateTime checkIn, DateTime checkOut)
    {
        User = user;
        Room = room;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Status = BookingStatus.Confirmed;
    }

    // Methods related to Booking, e.g., Cancel, ModifyDates
}

public class Payment
{
    public int Id { get; }
    public Booking Booking { get; private set; }
    public decimal Amount { get; private set; }
    public PaymentStatus Status { get; set; }
    public DateTime PaymentDate { get; private set; }

    public Payment(Booking booking, decimal amount)
    {
        Booking = booking;
        Amount = amount;
        Status = PaymentStatus.Pending;
        PaymentDate = DateTime.UtcNow;
    }

    // Methods related to Payment, e.g., ProcessPayment, Refund
}

public class Review
{
    public int Id { get; }
    public User User { get; private set; }
    public Hotel Hotel { get; private set; }
    public int Rating { get; private set; }
    public string Comment { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Review(User user, Hotel hotel, int rating, string comment)
    {
        User = user;
        Hotel = hotel;
        Rating = rating;
        Comment = comment;
        CreatedAt = DateTime.UtcNow;
    }

    // Methods related to Review, e.g., EditComment
}

public enum RoomType
{
    Single,
    Double,
    Suite
}

public enum BookingStatus
{
    Confirmed,
    Cancelled,
    Completed
}

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed,
    Refunded
}