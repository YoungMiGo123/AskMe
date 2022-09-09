using AskMe.Core.Core.Inputs;
using OpenAI_API;

namespace AskMe.Core.Core.Models.Interfaces
{
    public interface ISearchEngine
    {
        Task<string> CreateCompletion(OpenAiSearchRequest searchRequest);
        Task<string> CreateAndFormatCompletion(CompletionRequest completionRequest);
    }
}
