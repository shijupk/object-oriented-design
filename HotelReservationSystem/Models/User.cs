using HotelReservationSystem.Abstractions;

namespace HotelReservationSystem.Models;

public class User : Entity, IAggregateRoot
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; }
    // Additional properties like Role, ProfileInfo, etc.

    // Methods related to User, e.g., UpdateProfile, ChangePassword
}