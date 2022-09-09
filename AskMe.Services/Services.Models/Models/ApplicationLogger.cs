using AskMe.Services.Services.Models.Interfaces;
using Microsoft.Extensions.Logging;

namespace AskMe.Services.Services.Models.Models
{
    public class ApplicationLogger : IApplicationLogger
    {
        private readonly ILogger _logger;
        public ApplicationLogger(ILogger<ApplicationLogger> logger)
        {
            _logger = logger;
        }
        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
