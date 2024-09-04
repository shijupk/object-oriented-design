namespace RideSharingService.Features;

public class Ride
{
    public Rider Rider { get; private set; }
    public Driver Driver { get; }
    public Location PickupLocation { get; private set; }
    public Location DropoffLocation { get; private set; }
    public RideStatus Status { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }

    public Ride(Rider rider, Driver driver, Location pickup, Location dropoff)
    {
        Rider = rider;
        Driver = driver;
        PickupLocation = pickup;
        DropoffLocation = dropoff;
        Status = RideStatus.Booked;
    }

    public void StartRide()
    {
        Status = RideStatus.InProgress;
        StartTime = DateTime.Now;
        Driver.IsAvailable = false;
    }

    public void CompleteRide()
    {
        Status = RideStatus.Completed;
        EndTime = DateTime.Now;
        Driver.IsAvailable = true;
    }
}

public enum RideStatus
{
    Booked,
    InProgress,
    Completed,
    Cancelled
}