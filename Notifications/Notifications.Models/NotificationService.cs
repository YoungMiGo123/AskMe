using AskMe.Core.Core.Settings.Interfaces;
using AskMe.Notifications.Notifications.Interfaces;
using AskMe.Services.Services.Models.Interfaces;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace AskMe.Notifications.Notifications.Models
{
    public class NotificationService : INotificationService
    {
        private readonly IAskMeSettings _askMeSettings;
        private readonly IApplicationLogger _logger;
        public NotificationService(IAskMeSettings askMeSettings, IApplicationLogger logger)
        {
            _askMeSettings = askMeSettings;
            _logger = logger;
        }
        public async Task<string> SendEmailAsync(SendEmailModel sendEmail)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.mailbaby.net/mail/send"),
                Headers =
                {
                    { "X-API-KEY", _askMeSettings.EmailApiKey },
                },
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "to", sendEmail.ToEmail },
                    { "from", sendEmail.FromEmail},
                    { "subject", sendEmail.Subject },
                    { "body", sendEmail.Body },
                }),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var bodydata = await response.Content.ReadAsStringAsync();
                return bodydata;
            }
        }

        public async Task<string> SendTextMessage(SendTextMessage sendTextMessage)
        {

            string myURI = "https://api.bulksms.com/v1/messages";
            var sendMessageObject = JsonConvert.SerializeObject(new { to = sendTextMessage.ToPhoneNumber, body = sendTextMessage.Body });
            var request = WebRequest.Create(myURI);
            request.Credentials = new NetworkCredential(_askMeSettings.SMSUserName, _askMeSettings.SMSPassword);
            request.PreAuthenticate = true;
            request.Method = "POST";
            request.ContentType = "application/json";
            var encoding = new UnicodeEncoding();
            var encodedData = encoding.GetBytes(sendMessageObject);
            var stream = request.GetRequestStream();
            stream.Write(encodedData, 0, encodedData.Length);
            stream.Close();
            try
            {
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var result = await reader.ReadToEndAsync();
                return result;
            }
            catch (WebException ex)
            {
                var reader = new StreamReader(ex.Response.GetResponseStream());
                var result = "Error details:" + reader.ReadToEnd();
                _logger.LogError($"An error occurred while sending a message: {ex}\n\n\nDetailed exception: {result}");
                return result;
            }
        }
    }
}
