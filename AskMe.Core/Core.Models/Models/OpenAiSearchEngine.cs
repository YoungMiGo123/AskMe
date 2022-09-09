using AskMe.Core.Core.Inputs;
using AskMe.Core.Core.Models.Interfaces;
using AskMe.Core.Core.Settings.Interfaces;
using AskMe.Core.Core.Utilities;
using OpenAI_API;

namespace AskMe.Core.Core.Models.Models
{
    public class OpenAiSearchEngine : ISearchEngine
    {
        private OpenAIAPI OpenAIAPI;
        public OpenAiSearchEngine(IOpenAISettings openAiSettings)
        {
            OpenAIAPI = new OpenAIAPI(new APIAuthentication(openAiSettings.ApiKey), new Engine("text-davinci-002"));
        }
        public async Task<string> CreateCompletion(OpenAiSearchRequest searchRequest)
        {
            var maxToken = searchRequest.MaxTokens.HasValue ? searchRequest.MaxTokens.Value : OpenAiUtilities.BRIEFDESCRIPTION;
            var temparature = searchRequest.Temperature.HasValue ? searchRequest.Temperature.Value : 0;
            var result = await OpenAIAPI.Completions.CreateCompletionAsync(searchRequest.Query, maxToken, temparature);
            return result.Completions?.FirstOrDefault()?.Text ?? string.Empty;
        }

        public async Task<string> CreateAndFormatCompletion(CompletionRequest completionRequest)
        {
            var result = await OpenAIAPI.Completions.CreateAndFormatCompletion(completionRequest);
            return result;
        }
    }
}
