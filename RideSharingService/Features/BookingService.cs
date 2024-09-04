namespace RideSharingService.Features;

public class BookingService
{
    private readonly List<Driver> _drivers;
    private readonly IRideMatchingStrategy _matchingStrategy;
    private readonly List<Ride> _rides;

    public BookingService(IRideMatchingStrategy matchingStrategy, List<Driver> drivers)
    {
        _matchingStrategy = matchingStrategy;
        _drivers = drivers;
        _rides = new List<Ride>();
    }

    public Ride BookRide(RideRequest rideRequest)
    {
        var driver = _matchingStrategy.FindDriver(rideRequest, _drivers);

        if (driver == null)
        {
            throw new Exception("No available drivers found.");
        }

        var ride = new Ride(rideRequest.Rider, driver, rideRequest.PickupLocation, rideRequest.DropoffLocation);
        _rides.Add(ride);
        return ride;
    }

    public void StartRide(Ride ride)
    {
        ride.StartRide();
        // Notify rider and driver
    }

    public void CompleteRide(Ride ride)
    {
        ride.CompleteRide();
        // Process payment
        // Notify rider and driver
    }
}