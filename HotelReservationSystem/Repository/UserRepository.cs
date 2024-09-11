using HotelReservationSystem.Abstractions;
using HotelReservationSystem.Data;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Repository;

public interface IUserRepository : IRepository<User>
{
    User Add(User user);

    User Update(User user);

    Task<User> GetAsync(int userId);
}

public class UserRepository : IUserRepository
{
    private readonly BookingContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public UserRepository(BookingContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public User Add(User user)
    {
        if (user.IsTransient())
        {
            return _context.Users
                .Add(user)
                .Entity;
        }

        return user;
    }

    public User Update(User user)
    {
        return _context.Users
            .Update(user)
            .Entity;
    }

    public async Task<User> GetAsync(int userId)
    {
        var user = await _context.Users
            .Where(b => b.Id == userId)
            .SingleOrDefaultAsync();

        return user;
    }
}