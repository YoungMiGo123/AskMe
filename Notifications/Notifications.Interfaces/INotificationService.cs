using AskMe.Notifications.Notifications.Models;

namespace AskMe.Notifications.Notifications.Interfaces
{
    public interface INotificationService
    {
        Task<string> SendEmailAsync(SendEmailModel sendEmail);
        Task<string> SendTextMessage(SendTextMessage sendTextMessage);
    }

}
