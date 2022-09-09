using OpenAI_API;

namespace AskMe.Services.Services.Models.Interfaces
{
    public interface IResponseProcessor
    {
        public string ProcessSearchResults(string input);
    }
}
