using MovieTicketBookingSystem.Abstractions;

namespace MovieTicketBookingSystem.Features;

public class PaymentService : IPaymentService
{
    public void ProcessPayment(Booking booking, PaymentMethod paymentMethod)
    {
        paymentMethod.Pay(booking);

        if (booking.PaymentStatus == PaymentStatus.Completed)
        {
            Console.WriteLine($"Payment completed for booking {booking.Id}");
        }
        else
        {
            Console.WriteLine($"Payment failed for booking {booking.Id}");
        }
    }
}