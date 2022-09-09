using AskMe.Services.Services.Models.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace AskMe.Services.Services.Models.Models
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient client;
        private readonly IApplicationLogger _logger;

        public HttpService(IApplicationLogger logger)
        {
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            client = new HttpClient(handler);
            client.Timeout = TimeSpan.FromSeconds(60);
            _logger = logger;
        }
        public async Task<T> GetAsync<T>(string url)
        {
            try
            {
                var responseString = await client.GetStringAsync(url);
                var result = JsonConvert.DeserializeObject<T>(responseString);
                return result;
            }
            catch (Exception e)
            {
               _logger.LogError($"An error occured while processing this - {e}");
                return default;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string Url, TRequest model)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<TResponse>(responseString);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occured while processing this - {e}");
                return default;
            }
        }

        public async Task<string> PostAsync(string Url, string jsonObject)
        {
            try
            {
                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception e)
            {
                _logger.LogError($"An error occured while processing this - {e}");
                return string.Empty;
            }
        }
    }
}
