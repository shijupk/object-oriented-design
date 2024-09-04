namespace ParkingLot.Abstractions;

public enum VehicleSize
{
    Motorcycle,
    Compact,
    Large
}

public interface IVehicle
{
    string LicensePlate { get; }
    VehicleSize Size { get; }
}

public interface IParkingSpot
{
    int SpotNumber { get; }
    VehicleSize Size { get; }
    bool IsAvailable { get; }
    void ParkVehicle(IVehicle vehicle);
    void RemoveVehicle();
}

public interface IParkingTicket
{
    DateTime EntryTime { get; }
    IVehicle Vehicle { get; }
    int ParkingSpotNumber { get; }
}

public interface IPaymentProcessor
{
    decimal CalculateFee(IParkingTicket ticket);
    void ProcessPayment(IParkingTicket ticket, decimal amount);
}