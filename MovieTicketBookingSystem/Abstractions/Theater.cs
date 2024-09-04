namespace MovieTicketBookingSystem.Abstractions;

public class Theater
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public List<Screen> Screens { get; private set; }

    public Theater(string id, string name)
    {
        Id = id;
        Name = name;
        Screens = new List<Screen>();
    }
}

public class Screen
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public List<Seat> Seats { get; }

    public Screen(string id, string name, int seatCount)
    {
        Id = id;
        Name = name;
        Seats = new List<Seat>();
        for (var i = 1; i <= seatCount; i++)
        {
            Seats.Add(new Seat(i.ToString()));
        }
    }
}

public class Showtime
{
    public string Id { get; private set; }
    public Movie Movie { get; private set; }
    public Screen Screen { get; private set; }
    public DateTime StartTime { get; private set; }

    public Showtime(string id, Movie movie, Screen screen, DateTime startTime)
    {
        Id = id;
        Movie = movie;
        Screen = screen;
        StartTime = startTime;
    }
}