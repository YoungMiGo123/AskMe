using AskMe.Services.Services.Models.Interfaces;

namespace AskMe.Services.Services.Models.Models
{
    public class ResponseProcessor : IResponseProcessor
    {
        public string ProcessSearchResults(string input)
        {
            if (string.IsNullOrEmpty(input)) 
            {
                return string.Empty;
            }
            input = input.Trim();
            var firstChar = input.ElementAtOrDefault(0);
            var validChars = new List<char>() { '>', '<', '(', ')' };
            if (!char.IsLetterOrDigit(firstChar) && !validChars.Any(x => x == firstChar))
            {
                input = input[1..];
            }
            var result = input.Replace("\n\n\n", "\n").Replace("\n\n", "\n").Replace("\n", "<br/>");
            return result;
        }
    }
}
