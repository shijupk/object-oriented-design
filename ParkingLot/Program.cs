using ParkingLot.Abstractions;
using ParkingLot.Features;

namespace ParkingLot;

public class Program
{
    public static void Main(string[] args)
    {
        // Create parking spots
        var parkingSpots = new List<IParkingSpot>
        {
            new ParkingSpot(1, VehicleSize.Compact),
            new ParkingSpot(2, VehicleSize.Compact),
            new ParkingSpot(3, VehicleSize.Large),
            new ParkingSpot(4, VehicleSize.Motorcycle),
            new ParkingSpot(5, VehicleSize.Large)
        };

        // Create payment processor
        IPaymentProcessor paymentProcessor = new PaymentProcessor();

        // Create parking lot
        var parkingLot = new Features.ParkingLot(parkingSpots, paymentProcessor);

        // Park vehicles
        var car = new Car("ABC123");
        var truck = new Truck("XYZ789");

        var carTicket = parkingLot.ParkVehicle(car);
        var truckTicket = parkingLot.ParkVehicle(truck);

        // Remove vehicles
        parkingLot.RemoveVehicle(car.LicensePlate);
        parkingLot.RemoveVehicle(truck.LicensePlate);
    }
}