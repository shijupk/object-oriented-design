namespace MovieTicketBookingSystem.Abstractions;

public class Movie
{
    public string Id { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public TimeSpan Duration { get; private set; }

    public Movie(string id, string title, string description, TimeSpan duration)
    {
        Id = id;
        Title = title;
        Description = description;
        Duration = duration;
    }
}