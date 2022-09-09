namespace AskMe.Services.Services.Models.Interfaces
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url);
        Task<TResponse> PostAsync<TRequest, TResponse>(string Url, TRequest model);
        Task<string> PostAsync(string Url, string jsonObject);
    }
}
