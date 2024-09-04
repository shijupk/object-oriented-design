using ParkingLot.Abstractions;

namespace ParkingLot.Features;

public class PaymentProcessor : IPaymentProcessor
{
    private const decimal HourlyRate = 5.0m;

    public decimal CalculateFee(IParkingTicket ticket)
    {
        var duration = DateTime.Now - ticket.EntryTime;
        var hours = Math.Ceiling(duration.TotalHours);
        return (decimal)hours * HourlyRate;
    }

    public void ProcessPayment(IParkingTicket ticket, decimal amount)
    {
        Console.WriteLine(
            $"Payment of {amount:C} received for vehicle with license plate {ticket.Vehicle.LicensePlate}");
    }
}