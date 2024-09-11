using HotelReservationSystem.Data;
using HotelReservationSystem.Repository;
using HotelReservationSystem.Services;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BookingContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("BookingContext") ??
                              throw new InvalidOperationException("Connection string 'BookingContext' not found.")));

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IHotelRepository, HotelRepository>();
        builder.Services.AddScoped<IRoomRepository, RoomRepository>();
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();


        // Register base services
        builder.Services.AddScoped<IBookingService, BookingService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<BookingContext>();
            context.Database.EnsureCreated();
        }


        app.MapControllers();

        app.Run();
    }
}