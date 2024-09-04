using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaPlatform.Abstractions;

namespace SocialMediaPlatform.Features
{
    public interface INotificationService
    {
        void Notify(User user, string message);
    }

    public class NotificationService : INotificationService
    {
        private static NotificationService _instance;
        private static readonly object _lock = new();
        private readonly List<INotifier> _notifiers = new();

        public static NotificationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NotificationService();
                        }
                    }
                }

                return _instance;
            }
        }

        private NotificationService()
        {
            // Private constructor to prevent instantiation
        }

        public void Notify(User user, string message)
        {
            foreach (var notifier in _notifiers)
            {
                notifier.Send(user, message);
            }
        }

        public void AddNotifier(INotifier notifier)
        {
            _notifiers.Add(notifier);
        }
    }

    public interface INotifier
    {
        void Send(User user, string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Send(User user, string message)
        {
            // Implement email sending logic
            Console.WriteLine($"Email sent to {user.Email}: {message}");
        }
    }

    public class SmsNotifier : INotifier
    {
        public void Send(User user, string message)
        {
            // Implement SMS sending logic
            Console.WriteLine($"SMS sent to {user.Username}: {message}");
        }
    }
}
