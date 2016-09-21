using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SMS.Models;

namespace SMS.Services
{
    public static class RestService
    {
        private static HttpClient _client;
        private const string EMAIL_URL = "http://dhom.goteck.com.au/sendmail.php";
        private const string SMS_URL = "https://api.directsms.com.au/s3/rest/sms/send";

        static RestService()
        {
            _client = new HttpClient();
            //SetupProxy();
            _client.MaxResponseContentBufferSize = 256000;
        }

        static void SetupProxy()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = new WebProxy(new Uri("http://127.0.0.1:8888")),
                UseProxy = true
            };

            _client = new HttpClient(handler);
        }

        public static void SendEmail(string subject, string to, string body)
        {
            var data = "from=amalhu@deakin.com.au&to=" + to + "&subject=" + subject + "&message=" + body;
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(EMAIL_URL),
                Method = HttpMethod.Post,
                Content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded")
            };

            _client.SendAsync(request).Wait();
        }

        /// <summary>
        /// Sends the SMS using DirectSMS.
        /// curl -i \
        /// -X POST \
        /// -H "Content-Type: application/json" \
        /// -H "Accept: application/json" \
        /// -H "Username: Your directSMS username" \
        /// -H "Password: Your directSMS password" \
        /// -d '{
        /// "messageType": "1-way",
        /// "senderId": "directSMS",
        /// "messageText": "Test Message",
        /// "to": ["61411000111", "61411000222"]
        /// }'\
        /// -s https://api.directsms.com.au/s3/rest/sms/send
        /// </summary>
        /// <param name="phone">The phone.</param>
        /// <param name="text">The text.</param>
        public static void SendSMS( List<string> phones, string text)
        {            
            var json = JsonConvert.SerializeObject( new { messageType = "1-way", senderId = "Student management system", messageText = text, to = phones } );
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://api.directsms.com.au/s3/rest/sms/send"),
                Method = HttpMethod.Post,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            request.Headers.Add("Username", "dhom");
            request.Headers.Add("Password", "28a9079b");

            _client.SendAsync(request).Wait();

            //response = response;
        }
    }
}
