using ContentManagementSystem.Abstractions;

namespace ContentManagementSystem.Features;

public interface INotificationService
{
    void Notify(User user, string message);
}

public class EmailNotificationService : INotificationService
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending email to {user.Email}: {message}");
    }
}

public class SmsNotificationService : INotificationService
{
    public void Notify(User user, string message)
    {
        Console.WriteLine($"Sending SMS to {user.Username}: {message}");
    }
}