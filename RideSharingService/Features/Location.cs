namespace RideSharingService.Features;

public class Location
{
    public double X { get; set; }
    public double Y { get; set; }

    public Location(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public class TrackingService
{
    public void TrackRide(Ride ride)
    {
        // Implement real-time tracking logic
        Console.WriteLine($"Tracking ride from {ride.PickupLocation} to {ride.DropoffLocation}");
    }
}