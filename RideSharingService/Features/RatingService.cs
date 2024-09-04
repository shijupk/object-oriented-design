using RideSharingService.Abstractions;

namespace RideSharingService.Features;

public class Rating
{
    public User User { get; private set; }
    public int Score { get; private set; }
    public string Comment { get; private set; }

    public Rating(User user, int score, string comment)
    {
        User = user;
        Score = score;
        Comment = comment;
    }
}

public class RatingService
{
    private readonly List<Rating> _ratings;

    public RatingService()
    {
        _ratings = new List<Rating>();
    }

    public void RateRide(Ride ride, User user, int score, string comment)
    {
        var rating = new Rating(user, score, comment);
        _ratings.Add(rating);
        Console.WriteLine($"{user.Name} rated the ride with {score} stars. Comment: {comment}");
    }
}