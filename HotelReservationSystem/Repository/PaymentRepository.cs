using HotelReservationSystem.Abstractions;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Repository
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Payment AddPayment(Payment payment);

        Task<Payment> GetPaymentByIdAsync(int id);
        // Additional methods as needed
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly BookingContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PaymentRepository(BookingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Payment AddPayment(Payment payment)
        {
            if (payment.IsTransient())
            {
                return _context.Payment
                    .Add(payment)
                    .Entity;
            }

            return payment;
        }

        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            var payment = await _context.Payment
                .Where(b => b.Id == id)
                .SingleOrDefaultAsync();
            return payment;
        }
    }
}

