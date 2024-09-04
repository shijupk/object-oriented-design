using ParkingLot.Abstractions;

namespace ParkingLot.Features;

public class ParkingSpot : IParkingSpot
{
    private IVehicle _vehicle;

    public ParkingSpot(int spotNumber, VehicleSize size)
    {
        SpotNumber = spotNumber;
        Size = size;
        IsAvailable = true;
    }

    public int SpotNumber { get; }
    public VehicleSize Size { get; }
    public bool IsAvailable { get; private set; }

    public void ParkVehicle(IVehicle vehicle)
    {
        if (!IsAvailable || vehicle.Size > Size)
        {
            throw new InvalidOperationException("Parking spot is not available or vehicle is too large.");
        }

        _vehicle = vehicle;
        IsAvailable = false;
    }

    public void RemoveVehicle()
    {
        if (_vehicle == null)
        {
            throw new InvalidOperationException("Parking spot is already empty.");
        }

        _vehicle = null;
        IsAvailable = true;
    }
}