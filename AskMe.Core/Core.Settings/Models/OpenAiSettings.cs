using AskMe.Core.Core.Settings.Interfaces;

namespace AskMe.Core.Core.Settings.Models
{
    public class OpenAiSettings : IOpenAISettings
    {
        public string ApiKey { get; set; }
    }
}
