using RideSharingService.Abstractions;

namespace RideSharingService.Features;

public class Rider : User
{

    public Location Location { get; private set; }

    public Rider(string name, string phoneNumber) : base(name, phoneNumber)
    {
    }
}

public class Driver : User
{
    public string VehicleDetails { get; private set; }
    public bool IsAvailable { get; set; }
    
    public Location Location { get; private set; }
    public Driver(string name, string phoneNumber, string vehicleDetails)
        : base(name, phoneNumber)
    {
        VehicleDetails = vehicleDetails;
        IsAvailable = true;
    }
}