using ParkingLot.Abstractions;

namespace ParkingLot.Features;

public class Vehicle : IVehicle
{
    public Vehicle(string licensePlate, VehicleSize size)
    {
        LicensePlate = licensePlate;
        Size = size;
    }

    public string LicensePlate { get; }
    public VehicleSize Size { get; }
}

public class Motorcycle : Vehicle
{
    public Motorcycle(string licensePlate)
        : base(licensePlate, VehicleSize.Motorcycle)
    {
    }
}

public class Car : Vehicle
{
    public Car(string licensePlate)
        : base(licensePlate, VehicleSize.Compact)
    {
    }
}

public class Truck : Vehicle
{
    public Truck(string licensePlate)
        : base(licensePlate, VehicleSize.Large)
    {
    }
}