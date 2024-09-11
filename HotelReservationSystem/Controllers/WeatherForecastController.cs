using HotelReservationSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingController : ControllerBase
{
    

    private readonly ILogger<BookingController> _logger;

    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public IActionResult CreateBooking([FromBody] CreateBookingRequest request)
    {
        try
        {
            var booking =
                _bookingService.CreateBooking(request.UserId, request.RoomId, request.CheckIn, request.CheckOut);
            return Ok(booking);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{bookingId}/cancel")]
    public IActionResult CancelBooking(int bookingId)
    {
        try
        {
            _bookingService.CancelBooking(bookingId);
            return Ok("Booking cancelled successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserBookings(int userId)
    {
        var bookings = await _bookingService.GetUserBookings(userId);
        return Ok(bookings);
    }

    public class CreateBookingRequest
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}