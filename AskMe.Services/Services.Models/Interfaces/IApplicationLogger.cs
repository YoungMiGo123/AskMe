namespace AskMe.Services.Services.Models.Interfaces
{
    public interface IApplicationLogger
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogInformation(string message);
    }
}
