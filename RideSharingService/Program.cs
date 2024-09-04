using RideSharingService.Features;

namespace RideSharingService;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Initialize drivers and riders
        var driver1 = new Driver("John", "555-1234", "Toyota Prius");
        var driver2 = new Driver("Jane", "555-5678", "Honda Civic");
        var driver3 = new Driver("Jim", "555-8765", "Ford Focus");
        var drivers = new List<Driver> { driver1, driver2, driver3 };

        var rider = new Rider("Alice", "555-0000");

        // Step 2: Create ride request
        var pickupLocation = new Location(10.0, 10.0);
        var dropoffLocation = new Location(20.0, 20.0);
        var rideRequest = new RideRequest(rider, pickupLocation, dropoffLocation);

        // Step 3: Initialize services
        IRideMatchingStrategy matchingStrategy = new NearestDriverMatchingStrategy();
        var bookingService = new BookingService(matchingStrategy, drivers);
        IPaymentProcessor paymentProcessor = new CreditCardPaymentProcessor();
        var paymentService = new PaymentService(paymentProcessor);
        INotificationService notificationService = new EmailNotificationService();

        // Step 4: Book a ride
        try
        {
            var ride = bookingService.BookRide(rideRequest);
            Console.WriteLine($"Ride booked successfully with driver {ride.Driver.Name}!");

            // Notify the rider and driver
            notificationService.Notify(rider, "Your ride has been booked!");
            notificationService.Notify(ride.Driver, "You have a new ride request!");

            // Start the ride
            bookingService.StartRide(ride);
            Console.WriteLine("Ride started...");

            // Simulate ride duration (simplified)
            Thread.Sleep(2000); // Simulate the ride duration

            // Complete the ride
            bookingService.CompleteRide(ride);
            Console.WriteLine("Ride completed!");

            // Process payment
            var fare = CalculateFare(ride); // Simplified fare calculation
            paymentService.Charge(ride, fare);

            // Notify the rider and driver about the ride completion
            notificationService.Notify(rider, $"Your ride has been completed. Fare: {fare:C}");
            notificationService.Notify(ride.Driver, "Your ride has been completed.");

            // Rate the ride
            var ratingService = new RatingService();
            ratingService.RateRide(ride, rider, 5, "Great ride, thanks!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static decimal CalculateFare(Ride ride)
    {
        // Simplified fare calculation based on distance
        var distance = Math.Sqrt(Math.Pow(ride.DropoffLocation.X - ride.PickupLocation.X, 2) +
                                 Math.Pow(ride.DropoffLocation.Y - ride.PickupLocation.Y, 2));
        return (decimal)(distance * 1.5); // Example rate: $1.50 per unit distance
    }
}