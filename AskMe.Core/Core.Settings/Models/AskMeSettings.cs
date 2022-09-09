using AskMe.Core.Core.Settings.Interfaces;

namespace AskMe.Core.Core.Settings.Models
{
    public class AskMeSettings : IAskMeSettings
    {
        public string AskMeApiUrl { get; set; }
        public string FromEmail { get; set; }
        public string ConnectionString { get; set; }
        public string EmailApiKey { get; set; }
        public string SMSTokenId { get; set; }
        public string SMSTokenSecret { get; set; }
        public string SMSBasicAuth { get; set; }
        public string SMSUserName { get; set; }
        public string SMSPassword { get; set; }
    }
}
