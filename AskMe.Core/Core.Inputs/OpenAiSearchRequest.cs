namespace AskMe.Core.Core.Inputs
{
    public class OpenAiSearchRequest
    {
        public string Query { get; set; }
        public int? MaxTokens { get; set; }
        public int? Temperature { get; set; }
    }
}
