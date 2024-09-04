//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HotelBookingSystem.Entities;

//namespace HotelBookingSystem.Utilities
//{
//    public interface INotificationService
//    {
//        void Notify(User user, string message);
//    }

//    public class EmailNotificationService : INotificationService
//    {
//        private readonly IEmailSender _emailSender;

//        public EmailNotificationService(IEmailSender emailSender)
//        {
//            _emailSender = emailSender;
//        }

//        public void Notify(User user, string message)
//        {
//            var email = new EmailMessage
//            {
//                To = user.Email,
//                Subject = "Hotel Booking Notification",
//                Body = message
//            };
//            _emailSender.Send(email);
//        }
//    }

//    public interface IEmailSender
//    {
//        void Send(EmailMessage message);
//    }

//    public class SmtpEmailSender : IEmailSender
//    {
//        public void Send(EmailMessage message)
//        {
//            // Implementation using SMTP
//            Console.WriteLine($"Sending Email to {message.To}: {message.Subject} - {message.Body}");
//        }
//    }

//    public class EmailMessage
//    {
//        public string To { get; set; }
//        public string Subject { get; set; }
//        public string Body { get; set; }
//    }

//}

