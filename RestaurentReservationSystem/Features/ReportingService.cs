using RestaurentReservationSystem.Abstractions;

namespace RestaurentReservationSystem.Features;

public class ReservationReport
{
    public DateTime Date { get; }
    public int TotalReservations { get; }
    public int CompletedReservations { get; }
    public int CancelledReservations { get; }

    public ReservationReport(DateTime date, int total, int completed, int cancelled)
    {
        Date = date;
        TotalReservations = total;
        CompletedReservations = completed;
        CancelledReservations = cancelled;
    }

    public void PrintReport()
    {
        Console.WriteLine($"Reservation Report for {Date.ToShortDateString()}:");
        Console.WriteLine($"Total Reservations: {TotalReservations}");
        Console.WriteLine($"Completed Reservations: {CompletedReservations}");
        Console.WriteLine($"Cancelled Reservations: {CancelledReservations}");
    }
}

public class ReportingService
{
    private readonly List<Reservation> _reservations;

    public ReportingService(List<Reservation> reservations)
    {
        _reservations = reservations;
    }

    public ReservationReport GenerateDailyReport(DateTime date)
    {
        var total = 0;
        var completed = 0;
        var cancelled = 0;

        foreach (var reservation in _reservations)
        {
            if (reservation.ReservationTime.Date == date.Date)
            {
                total++;
                if (reservation.Status == ReservationStatus.Completed)
                {
                    completed++;
                }
                else if (reservation.Status == ReservationStatus.Cancelled)
                {
                    cancelled++;
                }
            }
        }

        return new ReservationReport(date, total, completed, cancelled);
    }
}