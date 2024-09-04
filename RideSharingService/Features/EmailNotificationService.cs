using RideSharingService.Abstractions;

namespace RideSharingService.Features;

public interface INotificationService
{
    void Notify(User user, string message);
}

public class EmailNotificationService : INotificationService
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending email to {user.Name}: {message}");
    }
}

public class SmsNotificationService : INotificationService
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending SMS to {user.Name}: {message}");
    }
}