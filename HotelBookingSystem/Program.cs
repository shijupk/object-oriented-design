using HotelBookingSystem.Services;

namespace HotelBookingSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Setup DI
        var serviceCollection = new ServiceCollection();
        var startup = new Startup();
        startup.ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();

        // Resolve the BookingService with the Logging Decorator applied
        var bookingService = serviceProvider.GetService<IBookingService>();

        // Use the booking service
        var booking = bookingService.CreateBooking(userId: 1, roomId: 101, checkIn: DateTime.Today,
            checkOut: DateTime.Today.AddDays(3));
        bookingService.CancelBooking(booking.Id);
    }
}