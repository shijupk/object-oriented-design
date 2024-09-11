using HotelReservationSystem.Abstractions;

namespace HotelReservationSystem.Models;

public enum RoomType
{
    Single,
    Double,
    Suite
}

public class Room : Entity, IAggregateRoot
{
    public int Id { get; set; }
    public int HotelId { get; set; }
    public Hotel Hotel { get; set; }

    public string RoomNumber { get; set; }
    public RoomType Type { get; set; }
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }


    // Methods related to Room, e.g., UpdatePrice, ChangeAvailability
}