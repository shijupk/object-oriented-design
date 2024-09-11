using HotelReservationSystem.Abstractions;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Repository
{
    public interface IReviewRepository : IRepository<Review>
    {
        Review AddReview(Review review);

        Task<IEnumerable<Review>> GetReviewsByHotel(int hotelId);
    }

    public class ReviewRepository : IRepository<Review>
    {
        private readonly BookingContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ReviewRepository(BookingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Review AddReview(Review review)
        {
            if (review.IsTransient())
            {
                return _context.Reviews
                    .Add(review)
                    .Entity;
            }

            return review;
        }

        public async Task<IEnumerable<Review>> GetReviewsByHotel(int hotelId)
        {
            var reviews = await _context.Reviews
                .Where(b => b.HotelId == hotelId)
                .ToListAsync();
            return reviews;
        }
    }
}
