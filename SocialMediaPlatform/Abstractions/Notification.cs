namespace SocialMediaPlatform.Abstractions;

public class Notification
{
    public User Recipient { get; }
    public string Message { get; }
    public DateTime Timestamp { get; private set; }

    public Notification(User recipient, string message)
    {
        Recipient = recipient;
        Message = message;
        Timestamp = DateTime.UtcNow;
    }

    public void Send()
    {
        Console.WriteLine($"Notification sent to {Recipient.Username}: {Message}");
    }
}