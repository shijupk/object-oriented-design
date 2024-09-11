using HotelReservationSystem.Abstractions;

namespace HotelReservationSystem.Models;

public class Review : Entity, IAggregateRoot
{
    public int Id { get; set; }
    public User User { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }


    // Methods related to Review, e.g., EditComment
}