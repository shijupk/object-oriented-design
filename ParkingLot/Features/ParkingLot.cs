using ParkingLot.Abstractions;

namespace ParkingLot.Features;

public class ParkingLot
{
    private readonly Dictionary<string, IParkingTicket> _activeTickets;
    private readonly List<IParkingSpot> _parkingSpots;
    private readonly IPaymentProcessor _paymentProcessor;

    public ParkingLot(List<IParkingSpot> parkingSpots, IPaymentProcessor paymentProcessor)
    {
        _parkingSpots = parkingSpots;
        _paymentProcessor = paymentProcessor;
        _activeTickets = new Dictionary<string, IParkingTicket>();
    }

    public IParkingTicket ParkVehicle(IVehicle vehicle)
    {
        var spot = _parkingSpots.FirstOrDefault(s => s.IsAvailable && s.Size >= vehicle.Size);
        if (spot == null)
        {
            throw new InvalidOperationException("No available parking spots for this vehicle.");
        }

        spot.ParkVehicle(vehicle);
        var ticket = new ParkingTicket(vehicle, spot.SpotNumber);
        _activeTickets[vehicle.LicensePlate] = ticket;

        return ticket;
    }

    public void RemoveVehicle(string licensePlate)
    {
        if (!_activeTickets.ContainsKey(licensePlate))
        {
            throw new InvalidOperationException("Vehicle not found in the parking lot.");
        }

        var ticket = _activeTickets[licensePlate];
        var spot = _parkingSpots.First(s => s.SpotNumber == ticket.ParkingSpotNumber);
        spot.RemoveVehicle();

        var fee = _paymentProcessor.CalculateFee(ticket);
        _paymentProcessor.ProcessPayment(ticket, fee);

        _activeTickets.Remove(licensePlate);
    }
}