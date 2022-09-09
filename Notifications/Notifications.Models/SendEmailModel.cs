namespace AskMe.Notifications.Notifications.Models
{
    public class SendEmailModel
    {
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string ToEmail { get; set; }
        public string Body { get; set; }
    }
}
