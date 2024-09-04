using HotelBookingSystem.Repository;
using HotelBookingSystem.Services;

namespace HotelBookingSystem;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();

        // Register base services
        services.AddScoped<IBookingService, BookingService>();

        // Register decorators
        services.Decorate<IBookingService, LoggingBookingServiceDecorator>();

        // Register notification services and others
        services.AddScoped<INotificationService, EmailNotificationService>();
        services.AddScoped<IEmailSender, SmtpEmailSender>();

        // Additional configurations
    }

    // Other configurations
}