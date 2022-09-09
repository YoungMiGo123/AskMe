using AskMe.Core.Core.Inputs;
using AskMe.Core.Core.Settings.Interfaces;
using AskMe.Services.Services.Models.Interfaces;
using Newtonsoft.Json;
using OpenAI_API;

namespace AskMe.Services.Services.Models.Models
{
    public class AskMeServiceAdapter : IAskMeServiceAdapter
    {
        private readonly IHttpService _httpService;
        private readonly IAskMeSettings _settings;
        private readonly IResponseProcessor _responseProcessor;

        public AskMeServiceAdapter(IHttpService httpService, IAskMeSettings settings, IResponseProcessor responseProcessor)
        {
            _httpService = httpService;
            _settings = settings;
            _responseProcessor = responseProcessor;
        }
        public async Task<string> SearchAsync(OpenAiSearchRequest searchReques)
        {
            var result = await _httpService.PostAsync($"{_settings.AskMeApiUrl}/api/AskMe/SearchAsync", JsonConvert.SerializeObject(searchReques));
            var response = _responseProcessor.ProcessSearchResults(result);
            return response;
        }
    }
}
