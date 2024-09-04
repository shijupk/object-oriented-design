using ParkingLot.Abstractions;

namespace ParkingLot.Features;

public class ParkingTicket : IParkingTicket
{
    public ParkingTicket(IVehicle vehicle, int parkingSpotNumber)
    {
        Vehicle = vehicle;
        ParkingSpotNumber = parkingSpotNumber;
        EntryTime = DateTime.Now;
    }

    public DateTime EntryTime { get; }
    public IVehicle Vehicle { get; }
    public int ParkingSpotNumber { get; }
}