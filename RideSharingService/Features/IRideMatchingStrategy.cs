namespace RideSharingService.Features;

public interface IRideMatchingStrategy
{
    Driver FindDriver(RideRequest rideRequest, IEnumerable<Driver> availableDrivers);
}

public class NearestDriverMatchingStrategy : IRideMatchingStrategy
{
    public Driver FindDriver(RideRequest rideRequest, IEnumerable<Driver> availableDrivers)
    {
        // Simplified nearest driver matching based on distance
        return availableDrivers
            .OrderBy(driver =>
                driver.IsAvailable ? Distance(rideRequest.PickupLocation, driver.Location) : double.MaxValue)
            .FirstOrDefault(driver => driver.IsAvailable);
    }

    private double Distance(Location loc1, Location loc2)
    {
        // Calculate the Euclidean distance as a simplification
        return Math.Sqrt(Math.Pow(loc1.X - loc2.X, 2) + Math.Pow(loc1.Y - loc2.Y, 2));
    }
}