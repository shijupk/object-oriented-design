using MovieTicketBookingSystem.Abstractions;

namespace MovieTicketBookingSystem.Features;

public class MovieService : IMovieService
{
    private readonly List<Movie> _movies;

    public MovieService()
    {
        _movies = new List<Movie>();
    }

    public Movie GetMovieDetails(string movieId)
    {
        return _movies.FirstOrDefault(m => m.Id == movieId);
    }

    public List<Movie> GetMoviesByTitle(string title)
    {
        return _movies.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void AddMovie(Movie movie)
    {
        _movies.Add(movie);
    }
}

public class ShowtimeService : IShowtimeService
{
    private readonly List<Showtime> _showtimes;

    public ShowtimeService()
    {
        _showtimes = new List<Showtime>();
    }

    public List<Showtime> GetShowtimesForMovie(string movieId)
    {
        return _showtimes.Where(s => s.Movie.Id == movieId).ToList();
    }

    public Showtime GetShowtimeDetails(string showtimeId)
    {
        return _showtimes.FirstOrDefault(s => s.Id == showtimeId);
    }

    public void AddShowtime(Showtime showtime)
    {
        _showtimes.Add(showtime);
    }
}

public class SeatSelectionService : ISeatSelectionService
{
    private readonly IShowtimeService _showtimeService;

    public SeatSelectionService(IShowtimeService showtimeService)
    {
        _showtimeService = showtimeService;
    }

    public List<Seat> GetAvailableSeats(string showtimeId)
    {
        var showtime = _showtimeService.GetShowtimeDetails(showtimeId);
        return showtime.Screen.Seats.Where(s => s.Status == SeatStatus.Available).ToList();
    }

    public void SelectSeat(Seat seat)
    {
        if (seat.Status == SeatStatus.Available)
        {
            seat.Status = SeatStatus.Reserved;
            Console.WriteLine($"Seat {seat.Id} reserved");
        }
        else
        {
            throw new InvalidOperationException("Seat is not available");
        }
    }
}