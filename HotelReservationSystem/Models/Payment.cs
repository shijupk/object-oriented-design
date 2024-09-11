using HotelReservationSystem.Abstractions;

namespace HotelReservationSystem.Models;

public enum PaymentStatus
{
    Pending,
    Completed,
    Failed,
    Refunded
}

public class Payment : Entity, IAggregateRoot
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime PaymentDate { get; set; }

    // Methods related to Payment, e.g., ProcessPayment, Refund
}