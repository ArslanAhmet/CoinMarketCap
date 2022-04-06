using System.Net.Http.Headers;
using System.Text;

namespace CoinMarketCap.Infrastructure.Services
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClientFactory(string url, string userName, string password)
        {
            baseAddress = url;
            UserName = userName;
            Password = password;
        }

        static string baseAddress { get; set; }
        private string UserName { get; set; }
        private string Password { get; set; }

        public HttpClient CreateClient()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
            //httpClientHandler.SslProtocols = SslProtocols.Tls13 | SslProtocols.Tls12 | SslProtocols.Tls11;
            var client = new HttpClient(httpClientHandler);
            SetupClientDefaults(client);
            return client;
        }

        protected virtual void SetupClientDefaults(HttpClient client)
        {
            //client.Timeout = TimeSpan.FromSeconds(30); //set your own timeout.
            //client.BaseAddress = new Uri(baseAddress);
            //var _httpClient = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.Timeout = new TimeSpan(0, 0, 30);
            client.DefaultRequestHeaders.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", "6396a60d-9a6e-4ffa-afa8-aa802e553ff0");

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            //        "Basic",
            //        Convert.ToBase64String(Encoding.ASCII.GetBytes($"{UserName}:{Password}")));
        }
    }
}
