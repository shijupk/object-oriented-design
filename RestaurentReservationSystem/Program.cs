using RestaurentReservationSystem.Abstractions;
using RestaurentReservationSystem.Features;

namespace RestaurentReservationSystem;

public class Program
{
    public static void Main(string[] args)
    {
        // Step 1: Initialize the system components
        var tables = new List<Table>
        {
            new(1, 4),
            new(2, 2),
            new(3, 6),
            new(4, 4)
        };

        var reservations = new List<Reservation>();

        INotificationService emailNotificationService = new EmailNotificationService();
        IPaymentProcessor paymentProcessor = new CreditCardPaymentProcessor();
        var paymentService = new PaymentService(paymentProcessor);
        var reportingService = new ReportingService(reservations);

        // Step 2: Create some customers
        var customer1 = new Customer("John Doe", "john@example.com");
        var customer2 = new Customer("Jane Smith", "jane@example.com");

        // Step 3: Make a reservation for customer1
        var reservationTime = DateTime.Now.AddHours(2);
        var reservedTable = tables.Find(t => t.IsAvailable && t.Capacity >= 4);

        if (reservedTable != null)
        {
            var reservation1 = new Reservation(customer1, reservedTable, reservationTime, 4);
            customer1.MakeReservation(reservation1);
            reservations.Add(reservation1);

            emailNotificationService.Notify(customer1,
                $"Your reservation for table {reservedTable.TableNumber} at {reservationTime} has been confirmed.");
            Console.WriteLine($"Reservation made for {customer1.Name} at table {reservedTable.TableNumber}.");
        }
        else
        {
            Console.WriteLine("No available table for the selected time and party size.");
        }

        // Step 4: Customer2 makes a reservation
        var reservedTable2 = tables.Find(t => t.IsAvailable && t.Capacity >= 2);
        if (reservedTable2 != null)
        {
            var reservation2 = new Reservation(customer2, reservedTable2, DateTime.Now.AddHours(3), 2);
            customer2.MakeReservation(reservation2);
            reservations.Add(reservation2);

            emailNotificationService.Notify(customer2,
                $"Your reservation for table {reservedTable2.TableNumber} at {reservation2.ReservationTime} has been confirmed.");
            Console.WriteLine($"Reservation made for {customer2.Name} at table {reservedTable2.TableNumber}.");
        }
        else
        {
            Console.WriteLine("No available table for the selected time and party size.");
        }

        // Step 5: Complete the reservation and process payment for customer1
        var completedReservation = customer1.Reservations[0];
        completedReservation.Complete();
        paymentService.Charge(100.00m); // Simulate a payment of $100
        Console.WriteLine(
            $"Reservation for {customer1.Name} at table {completedReservation.Table.TableNumber} has been completed.");

        // Step 6: Generate a daily report
        var reportDate = DateTime.Now.Date;
        var report = reportingService.GenerateDailyReport(reportDate);
        report.PrintReport();

        // Additional operations like cancellation, other notifications, etc., can be added similarly.
    }
}