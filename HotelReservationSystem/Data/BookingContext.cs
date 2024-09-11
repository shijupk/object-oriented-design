using System.Data;
using System.Diagnostics;
using HotelReservationSystem.Abstractions;
using HotelReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelReservationSystem.Data;

public class BookingContext : DbContext, IUnitOfWork
{
    private IDbContextTransaction _currentTransaction;
    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Hotel> Hotel { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    public bool HasActiveTransaction => _currentTransaction != null;

    public BookingContext(DbContextOptions<BookingContext> options) : base(options)
    {
        Debug.WriteLine("BookingContext::ctor ->" + GetHashCode());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        _ = await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    public IDbContextTransaction GetCurrentTransaction()
    {
        return _currentTransaction;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User");
        modelBuilder.Entity<Room>().ToTable("Room");
        modelBuilder.Entity<Review>().ToTable("Review");
        modelBuilder.Entity<Payment>().ToTable("Payment");
        modelBuilder.Entity<Review>().ToTable("Review");
        modelBuilder.Entity<Hotel>().ToTable("Hotel");
        modelBuilder.Entity<Booking>().ToTable("Booking");
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null)
        {
            return null;
        }

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null)
        {
            throw new ArgumentNullException(nameof(transaction));
        }

        if (transaction != _currentTransaction)
        {
            throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");
        }

        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (HasActiveTransaction)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    public void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (HasActiveTransaction)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}

