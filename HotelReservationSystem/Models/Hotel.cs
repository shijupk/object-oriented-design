using HotelReservationSystem.Abstractions;

namespace HotelReservationSystem.Models;

public class Hotel: Entity, IAggregateRoot
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public ICollection<Room> Rooms { get; set; }
    public ICollection<Review> Reviews { get; set; }
}