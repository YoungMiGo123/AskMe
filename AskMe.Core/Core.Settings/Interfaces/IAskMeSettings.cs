namespace AskMe.Core.Core.Settings.Interfaces
{
    public interface IAskMeSettings
    {
        public string AskMeApiUrl { get; set; }
        string FromEmail { get; set; }
        public string ConnectionString { get; set; }
        public string EmailApiKey { get; set; }
        public string SMSTokenId { get; set; }
        public string SMSTokenSecret { get; set; }
        public string SMSBasicAuth { get; set; }
        public string SMSUserName { get; set; }
        public string SMSPassword { get; set; }
    }
}
