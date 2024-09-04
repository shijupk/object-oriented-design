namespace RideSharingService.Features;

public class RideRequest
{
    public Rider Rider { get; private set; }
    public Location PickupLocation { get; private set; }
    public Location DropoffLocation { get; private set; }

    public RideRequest(Rider rider, Location pickup, Location dropoff)
    {
        Rider = rider;
        PickupLocation = pickup;
        DropoffLocation = dropoff;
    }
}