using AskMe.Core.Core.Inputs;
using OpenAI_API;

namespace AskMe.Services.Services.Models.Interfaces
{
    public interface IAskMeServiceAdapter
    {
        public Task<string> SearchAsync(OpenAiSearchRequest searchReques);
    }
}
